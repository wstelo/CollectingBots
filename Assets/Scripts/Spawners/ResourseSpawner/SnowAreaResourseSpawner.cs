using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowAreaResourseSpawner : ResourseSpawner<EnvironmentItem>
{
    public override void Start()
    {
        LayerIndex = TerrainLayersData.SnowLayer;
        base.Start();
    }
}
