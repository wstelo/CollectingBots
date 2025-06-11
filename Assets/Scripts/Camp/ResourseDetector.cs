using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _resoursesMask.value) != 0)
        {
            _resourses.Add(other);

            SortResoursesByDistance();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & _resoursesMask.value) != 0)
        {
            if (_resourses.Contains(other))
            {
                _resourses.Remove(other);
            }

            SortResoursesByDistance();
        }
    }
}
