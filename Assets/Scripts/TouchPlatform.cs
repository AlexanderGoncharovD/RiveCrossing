using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PLExternal.Map;
using UnityEngine;

public class TouchPlatform : MonoBehaviour
{
    #region Private Fields

    private bool _isLocked;

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

    private SpriteRenderer _spriteComponent;

    #endregion

    #region Properties

    public bool IsDrag => _isDrag;

    public Platform Platform { get; set; } = new Platform();

    /// <summary>
    ///     Платформа заблокирована для перемещения
    /// </summary>
    public bool IsLocked
    {
        get => _isLocked;
        set
        {
            _isLocked = value;

            if (value)
            {
                _spriteComponent.sprite = _gameControl.LockPlatformsSprites[length - 1];
                return;
            }
            _spriteComponent.sprite = _gameControl.PlatformsSprites[length - 1];
        }
    }

    #endregion

    public static GameObject Initialize(GameObject model, Vector3 position, Quaternion rotation, float length, Transform onePoint, Transform twoPoint)
    {
        var platform = MonoBehaviour.Instantiate(model, position, rotation);
        var component = platform.GetComponent<TouchPlatform>();
        platform.GetComponent<BoxCollider>().size = new Vector3(0.5f, length, 0.5f);
        component.Platform = new Platform(onePoint, twoPoint);

        component.Instantiate();

        return platform;
    }

    public void Instantiate()
    {
        _camera = Camera.main;
        _gameControl = _camera.GetComponent<GameControl>();
        _collider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        length = Mathf.CeilToInt(_collider.size.y);
        _spriteComponent = transform.GetComponentInChildren<SpriteRenderer>();
        _spriteComponent.sprite = _gameControl.PlatformsSprites[length - 1];
        tag = $"Platform{length}";

        _gameControl.Platforms.Add(this);

        var trigger = _gameControl.TriggerModels.First(_ => _.Platform.CoincidencesStrict(Platform));
        if (trigger.TouchPlatform == null)
        {
            this.trigger = trigger.Trigger;
            trigger.Trigger.TouchPlatform = this;
        }
    }
    
    private void Start()
    {
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
                        trigger.GetComponent<Trigger>().PlatformEnter(this);
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
        if (IsLocked)
        {
            return;
        }
        _collider.enabled = false;
        _animator.Play("Move");
    }

    private void OnMouseDrag()
    {
        if (IsLocked)
        {
            return;
        }
        _isDrag = true;
        _gameControl.DragPlatform = this;
        _gameControl.RecalculateAvailableTriggers();
        _gameControl.TriggerModels.ForEach(t =>
            {
                if (Mathf.CeilToInt(t.Length) != length)
                    t.GameObject.SetActive(false);
            }
        );
    }

    private void OnMouseUp()
    {
        if (IsLocked)
        {
            return;
        }
        _collider.enabled = true;
        _isDrag = false;
        _gameControl.DragPlatform = null;
        _gameControl.TriggerModels.ForEach(t => t.GameObject.SetActive(true));

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
        Platform = new Platform(trigger.Platform.First, trigger.Platform.Second);
        CacheFirstPosition();
        _gameControl.RecalculateAvailableTriggers();
    }
}
