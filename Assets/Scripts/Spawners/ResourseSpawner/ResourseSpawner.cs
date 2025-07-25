using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ResourseSpawner<T> : MonoBehaviour where T : EnvironmentItem
{
    [SerializeField] protected TerrainLayersData TerrainLayersData;
    [SerializeField] private SpawnPointHandler SpawnersHandler;
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _startCount = 30;

    protected int LayerIndex;
    protected ObjectPool<EnvironmentItem> Pool;

    private Vector3 _position = new Vector3(1, 20, 3);
    private int _poolMaxSize = 10;
    private int _currentActiveObjects = 0;
    private float _currentSpawnTime = 0.5f;

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

    public virtual void Start()
    {
        StartCoroutine(StartSpawn());
    }

    protected IEnumerator RefreshResourse()
    {
        var wait = new WaitForSeconds(_currentSpawnTime);

        while (enabled)
        {
            if (_currentActiveObjects < _startCount)
            {
                _currentActiveObjects++;
                EnableObject();
            }

            yield return wait;
        }
    }

    protected IEnumerator StartSpawn()
    {
        while (_currentActiveObjects < _startCount)
        {
                _currentActiveObjects++;
                EnableObject();

            yield return null;
        }

        StartCoroutine(RefreshResourse());
    }

    private void EnableObject()
    {
        EnvironmentItem currentObject = Pool.Get();
        currentObject.transform.position = SpawnersHandler.GetPointsToSpawn(LayerIndex);
    }

    private void Initialize(EnvironmentItem item)
    {
        item.transform.rotation = Quaternion.identity;
        item.gameObject.SetActive(true);
    }

    private void ReleasedObject(EnvironmentItem item)
    {
        _currentActiveObjects--;
        item.transform.SetParent(transform, true);
        Pool.Release(item);
    }

    private EnvironmentItem CreateObject()
    {
        EnvironmentItem item = Instantiate(_prefab, _position, Quaternion.identity, transform);
        item.Collected += ReleasedObject;

        return item;
    }

    private void DestroyObject(EnvironmentItem item)
    {
        item.Collected -= DestroyObject;
        Destroy(item.gameObject);
    }
}
