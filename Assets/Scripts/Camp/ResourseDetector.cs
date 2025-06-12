using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ResourseDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _resoursesMask;
    [SerializeField] private int _detectingRadius = 550;

    private SphereCollider _collider;

    public event Action <EnvironmentItem> Entered;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.isTrigger = true;
        _collider.radius = _detectingRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnvironmentItem item))
        {
            Entered?.Invoke(item);
        }
    }
}
