using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseCollector : MonoBehaviour
{
    public int StoneCount { get; private set; } = 0;
    public int TreeCount { get; private set; } = 0;
    public int IronCount { get; private set; } = 0;

    public void IncreaseStoneCount()
    {
        StoneCount += 1;
        Debug.Log($"{StoneCount} - Stone");
    }

    public void IncreaseTreeCount ()
    {
        TreeCount += 1;
        Debug.Log($"{TreeCount} - Tree");
    }

    public void IncreaseIronCount()
    {
        IronCount += 1;
        Debug.Log($"{IronCount} - Iron");
    }
}
