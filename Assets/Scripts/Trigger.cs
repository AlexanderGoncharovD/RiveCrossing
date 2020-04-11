using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Transform _platform;
    private Quaternion _rot;
    private Vector3 _pos;
    private Transform _transform;
    private TouchPlatform _touchPlatform;

    public int length;

    private void Start()
    {
        _transform = transform;
        _rot = _transform.rotation;
        _pos = _transform.position;
    }

    private void Update()
    {
        if (_platform != null && _touchPlatform != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (_touchPlatform.length == length)
                {
                    _platform.rotation = _rot;
                    _platform.position = _pos;
                    _touchPlatform.SetFirstTransform();
                }
                else
                {
                    _touchPlatform.RecoveryTransform();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals($"Platform{length}"))
        {
            _platform = other.transform;
            _platform.rotation = _rot;
            _touchPlatform = _platform.GetComponent<TouchPlatform>();
            _touchPlatform.trigger = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals($"Platform{length}"))
        {
            _platform = null;
            _touchPlatform.trigger = null;
            _touchPlatform = null;
        }
    }
}
