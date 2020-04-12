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
        
    }

    private void OnMouseDown()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        var nextPoint = _gameControl.Platforms.FirstOrDefault(p => p.First == CurPoint || p.Second == CurPoint);
        if (nextPoint != null)
        {
            _nextPoint = nextPoint.GetNextPoint(CurPoint);
            if (_nextPoint != null)
            {
                Move(nextPoint);
            }
        }
    }

    private void Move(PlatformPoints nextPoint)
    {
        transform.position = _nextPoint.position + new Vector3(0, 0, -1);
        CurPoint = _nextPoint;
        _nextPoint = null;
        _gameControl.Platforms.Remove(nextPoint);
        _gameControl.Platforms.Add(nextPoint);
    }
}
