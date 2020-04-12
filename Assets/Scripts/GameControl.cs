using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public List<Trigger> triggers = new List<Trigger>();

    /// <summary>
    ///     Платформа, которую тащем
    /// </summary>
    public Transform DragPlatform { get; set; }
    
    public List<PlatformPoints> Platforms { get; set; } = new List<PlatformPoints>();

    public Player Player { get; set; }

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
    
    #endregion
}
