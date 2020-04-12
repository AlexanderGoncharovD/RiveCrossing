using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPoints
{
    public Transform First;
    public Transform Second;

    public void SetPoints(Transform first, Transform second)
    {
        First = first;
        Second = second;
    }
}
