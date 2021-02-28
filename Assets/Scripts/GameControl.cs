using PLExternal.Level;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PLExternal;
using PLExternal.Map;
using UnityEngine;
using UnityEngine.Video;


public class GameControl : MonoBehaviour
{
    public List<Trigger> triggers = new List<Trigger>();
    public List<CapsuleCollider> pointsColliders = new List<CapsuleCollider>();

    /// <summary>
    ///     Платформа, которую тащем
    /// </summary>
    public TouchPlatform DragPlatform { get; set; }
    
    public List<TouchPlatform> Platforms { get; set; } = new List<TouchPlatform>();

    public Player Player { get; set; }

    public LevelPoint StartPoint { get; set; }
    public LevelPoint FinishPoint { get; set; }

    public Sprite[] PlatformsSprites;
    public Sprite[] LockPlatformsSprites;

    public List<TouchPlatform> UnlockedPlatforms = new List<TouchPlatform>();
    public List<LevelPoint> AvailablePoints = new List<LevelPoint>();
    public List<TriggerModel> TriggerModels = new List<TriggerModel>();
    public Dictionary<Transform, LevelPoint> LevelPoints = new Dictionary<Transform, LevelPoint>();

    private void Awake()
    {
    }

    void Start()
    {
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
        TriggerModels.ForEach(t => t.ChangeActivity(enabled));
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

    public void RecalculateAvailableTriggers()
    {
        AvailablePoints.Clear();
        AvailablePoints.Add(LevelPoints[Player.CurPoint]);
        var addPoints = new List<LevelPoint>();
        var newAddedPoints = new List<LevelPoint>(AvailablePoints);
        var checkedTriggers = new List<Platform>();
        var availableTriggers = new List<Platform>();

        do
        {
            addPoints.Clear();
            foreach (var availablePoint in newAddedPoints)
            {
                var triggers = GetTriggersPlatformFromPoint(availablePoint);
                if (triggers != null)
                {
                    availableTriggers.AddRange(triggers);
                    foreach (var trigger in triggers)
                    {
                        if (checkedTriggers.Contains(trigger))
                        {
                            continue;
                        }

                        if (IsHavePlatform(trigger))
                        {
                            foreach (var point in trigger.GetPoints())
                            {
                                if (!addPoints.Contains(point) && !AvailablePoints.Contains(point))
                                {
                                    addPoints.Add(point);
                                }
                            }
                        }
                        checkedTriggers.Add(trigger);
                    }
                }
            }

            AvailablePoints.AddRange(addPoints);
            newAddedPoints.Clear();
            newAddedPoints.AddRange(addPoints);

        } while (addPoints.Count != 0);

        foreach (var triggerModel in TriggerModels)
        {
            triggerModel.ChangeActivity(availableTriggers.Contains(triggerModel.Platform));
        }
    }

    private bool IsHavePlatform(Platform platform)
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

    private IEnumerable<Platform> GetTriggersPlatformFromPoint(LevelPoint point)
    {
        var triggers = new List<Platform>();

        foreach (var triggerModel in TriggerModels)
        {
            if (triggerModel.Platform.Coincidences(point))
            {
                triggers.Add(triggerModel.Platform);
            }
        }

        return triggers.Count > 0 ? triggers : null;
    }

    private IEnumerable<Platform> GetPlatformsFromPoint(LevelPoint point)
    {
        var platforms = new List<Platform>();

        foreach (var platform in Platforms)
        {
            if (platform.Platform.Coincidences(point))
            {
                platforms.Add(platform.Platform);
            }
        }

        return platforms.Count > 0 ? platforms : null;
    }
    
    #endregion
}
