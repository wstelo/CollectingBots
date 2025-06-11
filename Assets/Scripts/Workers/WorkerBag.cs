using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public EnvironmentItem GiveAwayProduct()
    {
        EnvironmentItem item = _currentProduct;
        _currentProduct.transform.SetParent(null, true);
        _currentProduct = null;
        return item;
    }
}
