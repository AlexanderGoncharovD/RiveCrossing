using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PLExternal.Map;
using UnityEngine;

public class TouchPlatform : MonoBehaviour
{
    #region Private Fields

    /// <summary>
    ///     Перемещается ли платформа
    /// </summary>
    private bool _isDrag = false;

    /// <summary>
    ///     Ссылка на камеру
    /// </summary>
    private Camera _camera;

    /// <summary>
    ///     Ссылка на класс управляющий уровнем
    /// </summary>
    private GameControl _gameControl;

    /// <summary>
    ///     Позиция перед перемещением
    /// </summary>
    private Vector3 _startPos;

    /// <summary>
    ///     Вращение перед перемещением
    /// </summary>
    private Quaternion _startRot;

    /// <summary>
    ///     Ссылка на комнонент коллайдера
    /// </summary>
    private BoxCollider _collider;

    private Animator _animator;

    #endregion

    #region Public Fields

    /// <summary>
    ///     Длина платформы
    /// </summary>
    public int length;

    /// <summary>
    ///     Триггер, на котором лежит или, в который вошла платформа
    /// </summary>
    public Trigger trigger;

    #endregion

    #region Properties

    public bool IsDrag => _isDrag;

    public PlatformPoints Points { get; set; } = new PlatformPoints();

    #endregion

    private void Start()
    {
        _camera = Camera.main;
        _gameControl = _camera.GetComponent<GameControl>();
        _collider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        length = Mathf.CeilToInt(_collider.size.y);
        transform.GetComponentInChildren<SpriteRenderer>().sprite = _gameControl.PlatformsSprites[length - 1];
        tag = $"Platform{length}";
        CacheFirstPosition();
    }

    private void Update()
    {
        if (_isDrag)
        {
            // Точка перемещения плтформы относительно курсора
            var point = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_camera.transform.position.z));
            this.transform.position = point;

            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Попадание луча из курсора в триггер
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Trigger"))
                {
                    if (trigger != hit.transform.GetComponent<Trigger>())
                    {
                        trigger?.GetComponent<Trigger>().PlatformExit();
                        trigger = hit.transform.GetComponent<Trigger>();
                        trigger.GetComponent<Trigger>().PlatformeEnter();
                    }
                }
                else
                {
                    trigger?.GetComponent<Trigger>().PlatformExit();
                    trigger = null;
                }
            }
            else
            {
                trigger?.GetComponent<Trigger>().PlatformExit();
                trigger = null;
            }
        }
    }

    private void OnMouseDown()
    {
        _collider.enabled = false;
        _animator.Play("Move");

    }

    private void OnMouseDrag()
    {
        _isDrag = true;
        _gameControl.DragPlatform = this.transform;
        _gameControl.triggers.ForEach(t =>
            {
                if (Mathf.CeilToInt(t.length) != length)
                    t.gameObject.SetActive(false);
            }
        );
    }

    private void OnMouseUp()
    {
        _collider.enabled = true;
        _isDrag = false;
        _gameControl.DragPlatform = null;
        _gameControl.triggers.ForEach(t => t.gameObject.SetActive(true));

        _animator.Play("Idle");

        if (trigger == null)
        {
            RecoveryPosition();
        }
        else
        {
            SetNewPosition();
        }
    }

    /// <summary>
    ///     Закешировать Положение платформы
    /// </summary>
    private void CacheFirstPosition()
    {
        _startPos = transform.position;
        _startRot = transform.rotation;
    }

    /// <summary>
    ///     Восстановить положение платформы
    /// </summary>
    private void RecoveryPosition()
    {
        transform.position = _startPos;
        transform.rotation = _startRot;
    }

    /// <summary>
    ///     Установить новое полдожения для платформы
    /// </summary>
    private void SetNewPosition()
    {
        transform.rotation = trigger.Rot;
        transform.position = trigger.Pos;
        Points.SetPoints(trigger.Points.First, trigger.Points.Second);
        CacheFirstPosition();
    }
}
