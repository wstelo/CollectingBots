using UnityEngine;

public class SpawnPointHandler : MonoBehaviour
{
    [SerializeField] private TerrainLayerHandler _terrainLayerHandler;
    [SerializeField] private float _obstacleRadius = 5;
    [SerializeField] private LayerMask _ObstacleMask;
    [SerializeField] private LayerMask _terrainMask;
    [SerializeField] private Terrain _terrain;

    private bool _isCorrectPoint = false;
    private bool _isCorrectHit = false;
    private Vector3 _startPointToRay;
    private float _maxHeight = 350f;
    private float _terrainHeight;
    private float _terrainWidth;

    private void Awake()
    {
        _terrainWidth = _terrain.terrainData.size.x;
        _terrainHeight = _terrain.terrainData.size.z;
        _startPointToRay = GetStartPointToRay();
    }

    public Vector3 GetPointOnNavMesh(Vector3 spawnPoint)
    {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(_startPointToRay, spawnPoint - _startPointToRay, out hit, Mathf.Infinity, _terrainMask);

        return hit.point;
    }

    public Vector3 GetPointsToSpawn(int layerIndex)
    {
        RaycastHit hit = new RaycastHit();
        _isCorrectHit = false;

        while (_isCorrectHit == false)
        {
            Physics.Raycast(_startPointToRay, GetPointOnArea(layerIndex) - _startPointToRay, out hit, Mathf.Infinity, _terrainMask | _ObstacleMask);

            if (((1 << hit.collider.gameObject.layer) & _terrainMask.value) != 0)
            {
                Collider[] hits = new Collider[10];
                int hitsCount = Physics.OverlapSphereNonAlloc(hit.point, _obstacleRadius, hits, _ObstacleMask);

                if (hitsCount == 0)
                {
                    _isCorrectHit = true;
                }
            }
        }

        return hit.point;
    }

    private Vector3 GetPointOnArea(int layerIndex)
    {
        Vector3 desiredPosition = new Vector3();
        _isCorrectPoint = false;

        while (_isCorrectPoint == false)
        {
            desiredPosition.x = Random.Range(_terrain.transform.position.x, _terrainWidth);
            desiredPosition.z = Random.Range(_terrain.transform.position.z, _terrainHeight);

            _isCorrectPoint = _terrainLayerHandler.IsCorrectPoint(desiredPosition, layerIndex);
        }

        return desiredPosition;
    }

    private Vector3 GetStartPointToRay()
    {
        return new Vector3(_terrain.terrainData.size.x / 2, _maxHeight, _terrain.terrainData.size.z / 2);
    }
}
