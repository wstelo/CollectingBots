using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampResourseCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WorkerBag bag))
        {         
            if(bag.IsUploaded)
            {
                EnvironmentItem product = bag.GiveAwayProduct();
                product.CollectedObject();
            }
        }
    }
}
