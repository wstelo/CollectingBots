using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAreaResourseSpawner : ResourseSpawner<EnvironmentItem>
{
    public override void Start()
    {
        LayerIndex = TerrainLayersData.ForestLayer;
        base.Start();
    }
}
