using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PLExternal.Map;
using UnityEngine;

public class TouchPlatform : MonoBehaviour
{
    #region Private Fields

    private bool _isLocked;
    private Trigger _trigger;
    private Trigger _cacheTrigger;

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
    private LevelManager _levelManager;

    /// <summary>
    ///     Позиция перед перемещением
    /// </summary>
    private Vector3 _cahcePosition;

    /// <summary>
    ///     Вращение перед перемещением
    /// </summary>
    private Quaternion _cacheRotation;

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
    public Trigger Trigger
    {
        get => _trigger;
        set
        {
            if (value != null)
            {
                _cacheTrigger = value;
            }

            _trigger = value;
        }
    }

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
                _spriteComponent.sprite = _levelManager.Helper.lockPlatformsSprites[length - 1];
                return;
            }
            _spriteComponent.sprite = _levelManager.Helper.platformsSprites[length - 1];
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
        _levelManager = _camera.GetComponent<LevelManager>();
        _collider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        length = Mathf.CeilToInt(_collider.size.y);
        _spriteComponent = transform.GetComponentInChildren<SpriteRenderer>();
        _spriteComponent.sprite = _levelManager.Helper.platformsSprites[length - 1];
        tag = $"Platform{length}";

        _levelManager.Platforms.Add(this);

        var trigger = _levelManager.TriggerModels.First(_ => _.Platform.CoincidencesStrict(Platform));
        if (trigger.TouchPlatform == null)
        {
            this.Trigger = trigger.Trigger;
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
                    if (Trigger != hit.transform.GetComponent<Trigger>())
                    {
                        Trigger?.GetComponent<Trigger>().PlatformExit();
                        Trigger = hit.transform.GetComponent<Trigger>();
                        Trigger.GetComponent<Trigger>().PlatformEnter(this);
                    }
                }
                else
                {
                    Trigger?.GetComponent<Trigger>().PlatformExit();
                    Trigger = null;
                }
            }
            else
            {
                Trigger?.GetComponent<Trigger>().PlatformExit();
                Trigger = null;
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
        _levelManager.DragPlatform = this;
        _levelManager.RecalculateAvailableTriggers();
        _levelManager.TriggerModels.ForEach(t =>
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
        _levelManager.DragPlatform = null;
        _levelManager.TriggerModels.ForEach(t => t.GameObject.SetActive(true));

        _animator.Play("Idle");

        if (Trigger == null)
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
        _cahcePosition = transform.position;
        _cacheRotation = transform.rotation;
    }

    /// <summary>
    ///     Восстановить положение платформы
    /// </summary>
    private void RecoveryPosition()
    {
        transform.position = _cahcePosition;
        transform.rotation = _cacheRotation;
        Trigger = _cacheTrigger;
        Trigger.TouchPlatform = this;
        _levelManager.RecalculateAvailableTriggers();
    }

    /// <summary>
    ///     Установить новое полдожения для платформы
    /// </summary>
    private void SetNewPosition()
    {
        transform.rotation = Trigger.Rot;
        transform.position = Trigger.Pos;
        Platform = new Platform(Trigger.Platform.First, Trigger.Platform.Second);
        CacheFirstPosition();
        _levelManager.RecalculateAvailableTriggers();
    }
}
