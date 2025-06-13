
public class DesertAreaResourseSpawner : ResourseSpawner<EnvironmentItem>
{
    public override void Start()
    {
        LayerIndex = TerrainLayersData.DesertLayer;
        base.Start();
    }
}
