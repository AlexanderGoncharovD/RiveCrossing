using System.Collections;
using System.Collections.Generic;
using PLExternal.Map;
using UnityEngine;

/// <summary>
///     Триггер расположения пути и длины пути от точки до точки
/// </summary>
public class Trigger : MonoBehaviour
{
    #region Private Fields

    private Quaternion _rot;
    private Vector3 _pos;
    private GameControl _gameControl;

    #endregion

    #region Public Fields
    
    /// <summary>
    ///     Длинна триггера. Длина пути от точки до точки
    /// </summary>
    public int length;

    #endregion

    #region Properties

    /// <summary>
    ///     Позиция триггера
    /// </summary>
    public Vector3 Pos => _pos;

    /// <summary>
    ///     Угол триггера
    /// </summary>
    public Quaternion Rot => _rot;

    public Platform Platform { get; set; } = new Platform();

    public TouchPlatform TouchPlatform;

    #endregion

    #region Private Methods

    private void Awake()
    {
        _gameControl = Camera.main.GetComponent<GameControl>();
    }

    private void Start()
    {
        _rot = transform.rotation;
        _pos = transform.position;
        GetComponentInChildren<SpriteRenderer>().sprite = _gameControl.PlatformsSprites[length - 1];
    }

    #endregion

    #region Public Methods

    /// <summary>
    ///     Платформа попала в триггер
    /// </summary>
    public void PlatformEnter(TouchPlatform touchPlatform)
    {
        if (_gameControl.DragPlatform != null)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            TouchPlatform = touchPlatform;
        }
    }

    /// <summary>
    ///     Платформа вышла из триггера
    /// </summary>
    public void PlatformExit()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        TouchPlatform = null;
    }

    #endregion
}
