﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchPlatform : MonoBehaviour
{
    private bool _isDrag = false;
    private Camera _camera;
    private GameControl _gameControl;
    private Vector3 _startPos;
    private Quaternion _startRot;

    public int length;
    public Trigger trigger;

    private void Start()
    {
        tag = $"Platform{length}";
        _camera = Camera.main;
        _gameControl = _camera.GetComponent<GameControl>();
        SetFirstTransform();
    }

    private void Update()
    {
        if (_isDrag)
        {
            Vector3 point = new Vector3();

            point = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_camera.transform.position.z));
            this.transform.position = point;
        }
    }

    private void OnMouseDown()
    {
    }

    private void OnMouseDrag()
    {
        _isDrag = true;
        _gameControl.triggers.ForEach(t =>
            {
                if (t.length != length)
                    t.gameObject.SetActive(false);
            }
        );
    }

    private void OnMouseUp()
    {
       _isDrag = false;
        if (trigger != null)
        {
            _gameControl.triggers.ForEach(t => t.gameObject.SetActive(true));
        }
        else
        {
            RecoveryTransform();
        }
    }

    public void SetFirstTransform()
    {
        _startPos = transform.position;
        _startRot = transform.rotation;
    }

    public void RecoveryTransform()
    {
        transform.position = _startPos;
        transform.rotation = _startRot;
    }
}
