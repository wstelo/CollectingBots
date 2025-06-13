public class Iron : EnvironmentItem
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
