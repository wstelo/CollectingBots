public class Stone : EnvironmentItem
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
