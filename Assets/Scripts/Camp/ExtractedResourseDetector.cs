using UnityEngine;

public class ExtractedResourseDetector : MonoBehaviour
{
    [SerializeField] private ResourseCollector _resourseCollector;

    private VisitorCollector _visitorCollector;

    private void Awake()
    {
        _visitorCollector = new VisitorCollector(_resourseCollector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WorkerBag bag))
        {
            if (bag.IsUploaded)
            {
                EnvironmentItem product = bag.GiveAwayCurrentProduct();
                product.CollectedObject();
                product.Accept(_visitorCollector);
            }
        }
    }
}