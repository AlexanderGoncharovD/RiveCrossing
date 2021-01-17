﻿using System.Collections;
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
    private Transform _visual;
    private Animator _animator;

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

    private void Start()
    {
        _gameControl = Camera.main.GetComponent<GameControl>();
        _line = GameObject.FindGameObjectWithTag("Line").GetComponent<LineRenderer>();
        _cameraHeight = Camera.main.transform.position.z;
        _rigidbody = GetComponent<Rigidbody>();
        _visual = transform.GetChild(0);
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
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

        _gameControl.ChangeEnabledTriggerPlatforms(false);
        _gameControl.ChangeEnabledColliderPoints(true);
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
                /*transform.position = _way.Last().position + new Vector3(0, 0, -1);
                CurPoint = _way.Last();*/
            }
            else
            {
                BreakMove();
            }
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

    /// <summary>
    ///     Перемещение персонажа
    /// </summary>
    private void PlayerMove()
    {
        CurPoint = _way.FirstOrDefault();

        if(CurPoint == null)
            return;

        _animator.Play("Run");

        if (Vector2.Distance(transform.position, CurPoint.position) < 0.05f)
        {
            _way.RemoveAt(0);

            if (!_way.Any())
            {
                BreakMove();
            }
        }

        var direction = (CurPoint.position - transform.position).normalized;
        var angle = GetDirectionInAngle(direction);

        _visual.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.Translate(direction * Time.deltaTime * speed);
    }

    /// <summary>
    ///     Остановить перемещение персонажа
    /// </summary>
    private void BreakMove()
    {
        _isPlayerMove = false;
        _animator.Play("Idle_v2");
        _way.Clear();
        _line.positionCount = 0;
        _gameControl.ChangeEnabledTriggerPlatforms(true);
        _gameControl.ChangeEnabledColliderPoints(false);
    }

    /// <summary>
    ///     Получить напрваление в градусах
    /// </summary>
    /// <param name="direction">
    ///     Напрваление до цели
    /// </param>
    /// <returns>
    ///     Поворот в градусах
    /// </returns>
    private static float GetDirectionInAngle(Vector3 direction)
    {
        var x = Mathf.RoundToInt(direction.x);
        var y = Mathf.RoundToInt(direction.y);
        var z = Mathf.RoundToInt(direction.z);

        if (y > 0)
            return 0;
        if (y < 0)
            return 180;
        if (x > 0)
            return 270;
        if (x < 0)
            return 90;
        return 0;
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
