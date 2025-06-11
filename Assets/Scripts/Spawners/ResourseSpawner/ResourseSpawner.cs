using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ResourseSpawner<T> : MonoBehaviour where T : EnvironmentItem
{
    [SerializeField] protected TerrainLayersData TerrainLayersData;
    [SerializeField] protected SpawnPointHandler SpawnersHandler;
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] protected int StartCount = 5;

    protected int LayerIndex;

    protected ObjectPool<EnvironmentItem> Pool;
    private Vector3 _position = new Vector3(1, 20, 3);
    private int _poolMaxSize = 10;
    private int _currentActiveObjects = 0;

    private void Awake()
    {
        Pool = new ObjectPool<EnvironmentItem>(
            createFunc: () => CreateObject(),
            actionOnGet: (item) => Initialize(item),
            actionOnRelease: (item) => item.gameObject.SetActive(false),
            defaultCapacity: _poolCapacity,
            actionOnDestroy: (item) => DestroyObject(item),
            maxSize: _poolMaxSize);
    }

    protected IEnumerator StartSpawn()
    {
        int currentCount = 0;

        while (currentCount < StartCount)
        {
            currentCount++;
            EnableObject();

            yield return null;
        }
    }

    private void EnableObject()
    {
        EnvironmentItem currentObject = Pool.Get();
        currentObject.transform.position = SpawnersHandler.GetPointsToSpawn(LayerIndex);
    }

    private void Initialize(EnvironmentItem item)
    {
        item.gameObject.SetActive(true);
        _currentActiveObjects++;
    }

    private void ReleasedObject(EnvironmentItem item)
    {
        _currentActiveObjects--;
        Pool.Release(item);
    }

    private EnvironmentItem CreateObject()
    {
        EnvironmentItem item = Instantiate(_prefab, _position, Quaternion.identity);
        item.Collected += ReleasedObject;

        return item;
    }

    private void DestroyObject(EnvironmentItem item)
    {
        item.Collected -= DestroyObject;
        Destroy(item.gameObject);
    }
}
