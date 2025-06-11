using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAreaResourseSpawner : ResourseSpawner<EnvironmentItem>
{
    private void Start()
    {
        LayerIndex = TerrainLayersData.ForestLayer;
        StartCoroutine(StartSpawn());
    }
}
