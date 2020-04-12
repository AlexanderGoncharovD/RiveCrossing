using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
///     Игрок
/// </summary>
public class Player : MonoBehaviour
{

    #region Private Fields

    private Transform _curPoint;
    private GameControl _gameControl;
    private Transform _nextPoint;

    private bool _isDraw;

    private List<Transform> _way = new List<Transform>();

    #endregion

    #region Properties

    /// <summary>
    ///     Точка на которой находится игрок
    /// </summary>
    public Transform CurPoint
    {
        get => _curPoint;
        set => _curPoint = value;
    }

    #endregion

    void Start()
    {
        _gameControl = Camera.main.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AppDebug.IsDebug)
        {
            Debuging();
        }

        if (_isDraw)
        {
            DrawWay();
        }
    }

    private void OnMouseDown()
    {
        _way.Add(CurPoint);
        _isDraw = true;
        //UpdatePosition();
    }

    public void UpdatePosition()
    {
        var nextPoint = _gameControl.Platforms.FirstOrDefault(p => p.First == CurPoint || p.Second == CurPoint);
        if (nextPoint != null)
        {
            _nextPoint = nextPoint.GetNextPoint(CurPoint);
            if (_nextPoint != null)
            {
                _way.Add(_nextPoint);
            }
        }
    }

    /// <summary>
    ///     Рисовать путь
    /// </summary>
    private void DrawWay()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _isDraw = false;
            if (_way.Any())
            {
                transform.position = _way.Last().position + new Vector3(0, 0, -1);
                CurPoint = _way.Last();
            }
            _way.Clear();
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Попадание луча из курсора в точку
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.CompareTag("Point"))
                    {
                        TryAddPoint(hit.transform.GetComponent<Point>());
                    }
                }
            }
        }
    }

    /// <summary>
    ///     Попытаться добавить точку в путь
    /// </summary>
    /// <param name="point">
    ///     Точка
    /// </param>
    public void TryAddPoint(Point point)
    {
        _nextPoint = point.transform;
        if (_nextPoint != null)
        {
            if (!_way.Contains(_nextPoint))
            {
                var lastPoint = _way.Any() ? _way.Last() : CurPoint;
                if (_gameControl.Platforms.Any(p => p.Comapre(lastPoint, _nextPoint)))
                {
                       _way.Add(_nextPoint);
                }
            }
        }
    }

    private void Debuging()
    {
        if (_way.Any())
        {
            var predPoint = CurPoint.position;
            foreach (var point in _way)
            {
                Debug.DrawLine(predPoint + new Vector3(0, 0, -2), point.position + new Vector3(0, 0, -2), Color.red);
                predPoint = point.position;
            }
        }
    }
}
