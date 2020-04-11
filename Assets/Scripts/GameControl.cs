using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public List<Trigger> triggers = new List<Trigger>();

    void Start()
    {
        triggers = GameObject.FindGameObjectsWithTag("Trigger").Select(g => g.GetComponent<Trigger>()).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
