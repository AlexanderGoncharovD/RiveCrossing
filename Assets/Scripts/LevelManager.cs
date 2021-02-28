using PLExternal.Level;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Helper;
using PLExternal;
using PLExternal.Enums;
using PLExternal.Map;
using UnityEngine;
using UnityEngine.Video;


[RequireComponent(typeof(LevelModelHelper))]
public class LevelManager : MonoBehaviour
{

    private LevelGenerator _generator;
    public List<CapsuleCollider> pointsColliders = new List<CapsuleCollider>();

    /// <summary>
    ///     Платформа, которую тащем
    /// </summary>
    public TouchPlatform DragPlatform { get; set; }
    
    /// <summary>
    ///     Все платформы на уровне
    /// </summary>
    public List<TouchPlatform> Platforms { get; set; } = new List<TouchPlatform>();

    public Player Player { get; set; }

    public LevelPoint StartPoint { get; set; }
    public LevelPoint FinishPoint { get; set; }

    public List<LevelPoint> AvailablePoints = new List<LevelPoint>();
    public List<TriggerModel> TriggerModels = new List<TriggerModel>();
    public Dictionary<Transform, LevelPoint> LevelPoints = new Dictionary<Transform, LevelPoint>();
    public LevelModelHelper Helper { get; private set; }

    private void Awake()
    {
        Helper = GetComponent<LevelModelHelper>();
        _generator = new LevelGenerator(this);
    }

    private void Start()
    {
        _generator.LoadLevel(7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Public Methods

    /// <summary>
    ///     Изменить состояние триггера платформ
    /// </summary>
    /// <param name="enabled">
    ///     True/False — включено/выключено
    /// </param>
    public void ChangeEnabledTriggerPlatforms(bool enabled)
    {
        TriggerModels.ForEach(t => t.ChangeActivity(enabled, MoveMode.Player));
    }

    /// <summary>
    ///     Изменить зону коллайдера точки
    /// </summary>
    /// <param name="enabled">
    ///     True/False — включено/выключено
    /// </param>
    public void ChangeEnabledColliderPoints(bool enabled)
    {
        pointsColliders.ForEach(p => p.enabled = enabled);
    }

    public void PlayerInitialized()
    {
        RecalculateAvailableTriggers();
    }

    /// <summary>
    ///     Пересчёт доступных триггеров для установки платформы
    /// </summary>
    public void RecalculateAvailableTriggers()
    {
        AvailablePoints.Clear();
        AvailablePoints.Add(LevelPoints[Player.CurPoint]);
        var addPoints = new List<LevelPoint>();
        var newAddedPoints = new List<LevelPoint>(AvailablePoints);
        var checkedTriggers = new List<Platform>();
        var availableTriggerPlatforms = new List<Platform>();

        do
        {
            addPoints.Clear();
            foreach (var availablePoint in newAddedPoints)
            {
                var triggers = GetTriggersModelFromPoint(availablePoint);
                if (triggers == null)
                {
                    continue;
                }
                
                foreach (var triggerModel in triggers)
                {
                    if (checkedTriggers.Contains(triggerModel.Platform))
                    {
                        continue;
                    }

                    if (TriggerHavePlatform(triggerModel.Platform))
                    {
                        foreach (var point in triggerModel.Platform.GetPoints())
                        {
                            if (!addPoints.Contains(point) && !AvailablePoints.Contains(point))
                            {
                                addPoints.Add(point);
                            }
                        }
                        availableTriggerPlatforms.Add(triggerModel.Platform);
                    }
                    else if (!triggerModel.IsCrossed(Platforms.Where(_ => _ != DragPlatform)))
                    {
                        availableTriggerPlatforms.Add(triggerModel.Platform);
                    }
                    checkedTriggers.Add(triggerModel.Platform);
                }
            }

            AvailablePoints.AddRange(addPoints);
            newAddedPoints.Clear();
            newAddedPoints.AddRange(addPoints);

        } while (addPoints.Count != 0);

        foreach (var triggerModel in TriggerModels)
        {
            triggerModel.ChangeActivity(availableTriggerPlatforms.Contains(triggerModel.Platform), MoveMode.Platform);
        }
    }

    /// <summary>
    ///     Проверяет наличие платформы у триггера
    /// </summary>
    /// <param name="platform">Координаты расположения триггера</param>
    private bool TriggerHavePlatform(Platform platform)
    {
        foreach (var touchPlatform in Platforms.Where(_ => _ != DragPlatform))
        {
            if (touchPlatform.Platform.CoincidencesStrict(platform))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Находит список тригеров соприкасающихся с точкой и возвращает их модели
    /// </summary>
    private IEnumerable<TriggerModel> GetTriggersModelFromPoint(LevelPoint point)
    {
        var triggers = new List<TriggerModel>();

        foreach (var triggerModel in TriggerModels)
        {
            if (triggerModel.Platform.Coincidences(point))
            {
                triggers.Add(triggerModel);
            }
        }

        return triggers.Count > 0 ? triggers : null;
    }
    
    #endregion
}
