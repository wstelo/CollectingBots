using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(ResourseDetector))]

public class ResourseHandler : MonoBehaviour
{
    private List<EnvironmentItem> _resourses = new List<EnvironmentItem>();
    private ResourseDetector _resourseDetector;

    public int AvailableResourse => _resourses.Count;

    private void Awake()
    {
        _resourseDetector = GetComponent<ResourseDetector>();
    }

    private void OnEnable()
    {
        _resourseDetector.Entered += AddObject;
    }

    private void OnDisable()
    {
        _resourseDetector.Entered -= AddObject;
    }

    private void AddObject(EnvironmentItem item)
    {
        _resourses.Add(item);
    }

    public EnvironmentItem GetRandomNearestItem()
    {
        if(_resourses.Count != 0)
        {
            EnvironmentItem resourse = _resourses.OrderBy(x => gameObject.transform.position.SqrDistance(x.transform.position)).First();
            _resourses.Remove(resourse);

            return resourse;
        }

        return null;
    }
}
