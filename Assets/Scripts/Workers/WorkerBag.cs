using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class WorkerBag : MonoBehaviour
{
    [SerializeField] Transform _productPosition;

    private EnvironmentItem _currentProduct = null;

    public bool IsUploaded => _currentProduct != null;

    public void PlaceProduct(EnvironmentItem item)
    {
        _currentProduct = item;
        item.transform.SetParent(_productPosition, true);
        item.transform.localPosition = Vector3.zero;
    }

    public IResoursable GiveAwayCurrentProduct()
    {
        if(_currentProduct.TryGetComponent(out IResoursable item1))
        {
            _currentProduct.transform.SetParent(null, true);
            _currentProduct = null;
            return item1;
        }
        
        return null;
    }
}
