public class ForestAreaResourseSpawner : ResourseSpawner<EnvironmentItem>
{
    public override void Start()
    {
        LayerIndex = TerrainLayersData.ForestLayer;
        base.Start();
    }
}
