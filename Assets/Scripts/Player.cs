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
    private LineRenderer _line;
    /// <summary>
    ///     Отдалённость камеры от нуля
    /// </summary>
    private float _cameraHeight;
    private bool _isDraw;
    private List<Transform> _way = new List<Transform>();
    private bool _isPlayerMove = false;
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    public Sprite Idle;
    
    public Sprite Move;
    public float speed = 1.0f;


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
        _line = GameObject.FindGameObjectWithTag("Line").GetComponent<LineRenderer>();
        _cameraHeight = Camera.main.transform.position.z;
        _rigidbody = GetComponent<Rigidbody>();
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

        if (_isPlayerMove)
        {
            PlayerMove();
        }
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        _way.Add(CurPoint);
        _line.positionCount = 2;
        _line.SetPosition(0, CurPoint.position);
        _isDraw = true;
        //  Отключить триггеры платформ
        _gameControl.triggers.ForEach(t => t.GetComponent<BoxCollider>().enabled = false);
        //  Включить зону коллайдера точки
        _gameControl.pointsColliders.ForEach(p => p.enabled = true);
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
                _isPlayerMove = true;
                transform.position = _way.Last().position + new Vector3(0, 0, -1);
                CurPoint = _way.Last();
            }
            _way.Clear();
            _line.positionCount = 0;
            //  Включить триггеры платформ
            _gameControl.triggers.ForEach(t => t.GetComponent<BoxCollider>().enabled = true);
            //  Отключить зону коллайдера точки
            _gameControl.pointsColliders.ForEach(p => p.enabled = false);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                SetLineToCursor();
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
                    _line.SetPosition(_line.positionCount - 1, _nextPoint.position);
                    _line.positionCount++;
                    SetLineToCursor();
                }
            }
        }
    }

    private void SetLineToCursor()
    {
        _line.SetPosition(_line.positionCount - 1, Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0, 0, _cameraHeight));
    }

    private void PlayerMove()
    {
        /*CurPoint = _way.First();
        transform.LookAt(CurPoint);
        if (Vector3.Distance(transform.position, CurPoint.position) < 1.15f)
        {
            _way.RemoveAt(0);
        }*/
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
