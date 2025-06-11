using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SphereCollider))]

public class ResourseHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _resoursesMask;
    [SerializeField] private int _detectingRadius = 100;

    private List<Collider> _resourses = new List<Collider>();
    private List<Collider> _sortedResourses = new List<Collider>();
    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.isTrigger = true;
        _collider.radius = _detectingRadius;
    }

    public EnvironmentItem GetRandomNearestItem()
    {
        if(_sortedResourses.Count != 0)
        {
            _sortedResourses[0].TryGetComponent(out EnvironmentItem resourse);
            _sortedResourses.Remove(_sortedResourses[0]);

            return resourse;
        }

        return null;
    }

    public void RemoveResourse(EnvironmentItem item)
    {
        item.TryGetComponent(out Collider collider);

        if (_sortedResourses.Contains(collider))
        {
            _sortedResourses.Remove(collider);
            SortResoursesByDistance();
        }
    }

    private void SortResoursesByDistance()
    {
        _sortedResourses = _resourses.OrderBy(x => gameObject.transform.position.SqrDistance(x.transform.position)).ToList();
    }
}
