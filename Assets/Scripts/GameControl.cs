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
    public Transform DragPlatform { get; set; }
    
    public List<TouchPlatform> Platforms { get; set; } = new List<TouchPlatform>();

    public Player Player { get; set; }

    public LevelPoint StartPoint { get; set; }
    public LevelPoint FinishPoint { get; set; }

    public Sprite[] PlatformsSprites;
    public Sprite[] LockPlatformsSprites;

    public List<TouchPlatform> UnlockedPlatforms = new List<TouchPlatform>();

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

    public void UpdateTriggerList()
    {
        triggers = GameObject.FindGameObjectsWithTag("Trigger").Select(g => g.GetComponent<Trigger>()).ToList();
    }

    /// <summary>
    ///     Изменить состояние триггера платформ
    /// </summary>
    /// <param name="enabled">
    ///     True/False — включено/выключено
    /// </param>
    public void ChangeEnabledTriggerPlatforms(bool enabled)
    {
        triggers.ForEach(t => t.GetComponent<BoxCollider>().enabled = enabled);
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

    public void CheckUnlocked(TouchPlatform platform)
    {
        if(!UnlockedPlatforms.Any())
        {
            if (platform.Platform.Coincidences(StartPoint))
            {
                AddUnlockedPlatform(platform);
                return;
            }

            RemoveUnlockedPlatform(platform);
            return;
        }

        foreach (var unlockedPlatform in UnlockedPlatforms)
        {
            if (unlockedPlatform.Platform.Coincidences(platform.Platform))
            {
                AddUnlockedPlatform(platform);
                continue;
            }

            RemoveUnlockedPlatform(platform);
        }
    }

    private void AddUnlockedPlatform(TouchPlatform platform)
    {
        if (!UnlockedPlatforms.Contains(platform))
        {
            UnlockedPlatforms.Add(platform);
        }
        platform.IsLocked = false;
    }

    private void RemoveUnlockedPlatform(TouchPlatform platform)
    {
        if (UnlockedPlatforms.Contains(platform))
        {
            UnlockedPlatforms.Remove(platform);
        }
        platform.IsLocked = true;
    }

    public void ChangeLockedPlatforms(LevelPoint point)
    {
        /*var unlockedTriggers = triggers.Where(t 
            => t.Platform.Coincidences(point))
            .ToList();

        Platforms.ForEach(platform =>
            {
                if (unlockedTriggers.Contains(platform.trigger))
                {
                    platform.IsLocked = false;
                }
                else
                {
                    platform.IsLocked = true;
                }
            }
        );*/
    }

    #endregion
}
