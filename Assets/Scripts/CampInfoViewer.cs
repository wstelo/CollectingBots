using UnityEngine;
using TMPro;

public class CampInfoViewer : MonoBehaviour
{
    [SerializeField] private ResourseCollector _resourseCollector;
    [SerializeField] private TMP_Text _woodCountText;
    [SerializeField] private TMP_Text _stoneCountText;
    [SerializeField] private TMP_Text _ironCountText;

    private void OnEnable()
    {
        _resourseCollector.IronCountChanged += RefreshIronCount;
        _resourseCollector.WoodCountChanged += RefreshTreeCount;
        _resourseCollector.StoneCountChanged += RefreshStoneCount;
    }

    private void OnDisable()
    {
        _resourseCollector.IronCountChanged -= RefreshIronCount;
        _resourseCollector.WoodCountChanged -= RefreshTreeCount;
        _resourseCollector.StoneCountChanged -= RefreshStoneCount;
    }

    private void RefreshTreeCount(int count)
    {
        _woodCountText.text = count.ToString();
    }

    private void RefreshStoneCount(int count)
    {
        _stoneCountText.text = count.ToString();
    }

    private void RefreshIronCount( int count)
    {
        _ironCountText.text = count.ToString();
    }
}
