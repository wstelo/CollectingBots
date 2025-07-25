using System;
using UnityEngine;

public class WorkerColllisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _resourseMask;

    public event Action <EnvironmentItem> ResourseDetected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnvironmentItem item))
        {
            ResourseDetected?.Invoke(item);
        }
    }
}
