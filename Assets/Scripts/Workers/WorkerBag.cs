using UnityEngine;

public class WorkerBag : MonoBehaviour
{
    [SerializeField] Transform _productPosition;

    private EnvironmentItem _currentProduct = null;

    public bool IsUploaded => _currentProduct != null;

    public void PlaceProduct(EnvironmentItem item)
    {
        _currentProduct = item;
        _currentProduct.SetAsChild(_productPosition);
    }

    public EnvironmentItem GiveAwayCurrentProduct()
    {
        _currentProduct.SetAsFree();
        EnvironmentItem tempProduct = _currentProduct;
        _currentProduct = null;
        return tempProduct;
    }
}
