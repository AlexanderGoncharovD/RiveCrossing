using System.Collections;
using System.Collections.Generic;
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

    public PlatformPoints Points { get; set; } = new PlatformPoints();

    #endregion

    #region Private Methods

    private void Start()
    {
        _rot = transform.rotation;
        _pos = transform.position;
        _gameControl = Camera.main.GetComponent<GameControl>();
    }

    #endregion

    #region Public Methods

    /// <summary>
    ///     Платформа попала в триггер
    /// </summary>
    public void PlatformeEnter()
    {
        if (_gameControl.DragPlatform != null)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    /// <summary>
    ///     Платформа вышла из триггера
    /// </summary>
    public void PlatformExit()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    #endregion
}
