using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertAreaResourseSpawner : ResourseSpawner<EnvironmentItem>
{
    private void Start()
    {
        LayerIndex = TerrainLayersData.DesertLayer;
        StartCoroutine(StartSpawn());
    }
}
