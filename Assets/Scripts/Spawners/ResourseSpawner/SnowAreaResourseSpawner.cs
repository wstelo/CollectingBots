using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowAreaResourseSpawner : ResourseSpawner<EnvironmentItem>
{
    private void Start()
    {
        LayerIndex = TerrainLayersData.SnowLayer;
        StartCoroutine(StartSpawn());
    }
}
