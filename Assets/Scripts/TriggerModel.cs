using System;
using System.Collections.Generic;
using System.Linq;
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

    /// <summary>
    ///     Имеется ли пересечение хотя бы с одной платформой
    /// </summary>
    /// <param name="platforms">Список платформ, с которыми проверяется пересечение</param>
    /// <returns></returns>
    public bool IsCrossed(IEnumerable<TouchPlatform> platforms)
    {
        var internalPointsOfTrigger = GetInternalPoints(Platform);

        var internalPointsOfPlatforms = new List<LevelPoint>();

        foreach (var platform in platforms)
        {
            internalPointsOfPlatforms.AddRange(GetInternalPoints(platform.Platform));
        }

        foreach (var point in internalPointsOfTrigger)
        {
            if (internalPointsOfPlatforms.Contains(point))
            {
                return true;
            }
        }


        return false;
    }

    /// <summary>
    ///     Находит внутренние точки платформы
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<LevelPoint> GetInternalPoints(Platform platform)
    {
        var points = new List<LevelPoint>();

        if (platform.FirstPoint.Row == platform.SecondPoint.Row)
        {
            for (var col = platform.FirstPoint.Column + 1; col < platform.SecondPoint.Column; col++)
            {
                points.Add(new LevelPoint(platform.FirstPoint.Row, col));
            }
        }
        else if (platform.FirstPoint.Column == platform.SecondPoint.Column)
        {
            for (var row = platform.FirstPoint.Row + 1; row < platform.SecondPoint.Row; row++)
            {
                points.Add(new LevelPoint(row, platform.FirstPoint.Column));
            }
        }

        return points;
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
