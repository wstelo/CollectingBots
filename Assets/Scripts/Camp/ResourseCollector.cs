using System;
using UnityEngine;

public class ResourseCollector : MonoBehaviour
{
    private int _stoneCount = 0;
    private int _treeCount = 0;
    private int _ironCount = 0;

    public event Action <int> WoodCountChanged;
    public event Action <int> StoneCountChanged;
    public event Action <int> IronCountChanged;

    public void IncreaseStoneCount()
    {
        _stoneCount += 1;
        StoneCountChanged?.Invoke(_stoneCount);
    }

    public void IncreaseTreeCount ()
    {
        _treeCount += 1;
        WoodCountChanged?.Invoke(_treeCount);
    }

    public void IncreaseIronCount()
    {
        _ironCount += 1;
        IronCountChanged?.Invoke(_ironCount);
    }
}
