using System;
using System.Collections.Generic;
using System.Text;
using PLExternal.Enums;
using PLExternal.Level;
using PLExternal.Map;
using UnityEngine;

/// <summary>
///     Модель зоны установки платформы
/// </summary>
public struct TriggerModel
{

    public bool IsEmpty => GameObject == null || Trigger == null;
    /// <summary>
    ///     Объект Unity
    /// </summary>
    public GameObject GameObject { get; private set; }

    /// <summary>
    ///     Класс триггера
    /// </summary>
    public Trigger Trigger { get; private set; }

    /// <summary>
    ///     Модель координат триггера
    /// </summary>
    public Platform Platform => Trigger.Platform;

    /// <summary>
    ///     Длина триггера
    /// </summary>
    public int Length => Trigger.length;

    /// <summary>
    ///     Коллайдер триггера
    /// </summary>
    public BoxCollider Collider { get; }

    public TouchPlatform TouchPlatform => Trigger?.TouchPlatform;

    public TriggerModel(GameObject obj, Trigger trigger)
    {
        GameObject = obj;
        Trigger = trigger;
        Collider = obj?.GetComponent<BoxCollider>();
    }
    
    /// <summary>
    ///     Изменить активность платформы
    /// </summary>
    public void ChangeActivity(bool value, MoveMode mode)
    {
        Collider.enabled = value;

        if (TouchPlatform != null && mode == MoveMode.Platform)
        {
            TouchPlatform.IsLocked = !value;
        }
    }

    public static TriggerModel Empty()
    {
        return new TriggerModel(null, null);
    }

    public override string ToString()
    {
        return Platform.ToString();
    }
}
