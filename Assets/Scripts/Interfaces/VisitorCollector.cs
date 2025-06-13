public class VisitorCollector : IVisitor
{
    private ResourseCollector _collector;

    public VisitorCollector(ResourseCollector collector)
    {
        _collector = collector;
    }

    public void Visit(Stone stone)
    {
        _collector.IncreaseStoneCount();
    }

    public void Visit(Tree tree)
    {
        _collector.IncreaseTreeCount();
    }

    public void Visit(Iron iron)
    {
        _collector.IncreaseIronCount();
    }
}
