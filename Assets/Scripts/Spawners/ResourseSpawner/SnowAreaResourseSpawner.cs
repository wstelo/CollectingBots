
public class SnowAreaResourseSpawner : ResourseSpawner<EnvironmentItem>
{
    public override void Start()
    {
        LayerIndex = TerrainLayersData.SnowLayer;
        base.Start();
    }
}
