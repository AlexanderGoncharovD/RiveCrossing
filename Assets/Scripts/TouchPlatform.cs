using System.Collections;
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
        GetComponent<BoxCollider>().size = new Vector3(1.0f, 0.5f, 1.0f);
    }

    private void OnMouseDrag()
    {
        _isDrag = true;
        _gameControl.triggers.ForEach(t =>
            {
                if (Mathf.CeilToInt(t.length) != length)
                    t.gameObject.SetActive(false);
            }
        );
    }

    private void OnMouseUp()
    {
        GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f);
        _isDrag = false;
        _gameControl.triggers.ForEach(t => t.gameObject.SetActive(true));
        if (trigger == null)
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
