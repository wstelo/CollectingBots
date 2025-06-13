public  class Tree : EnvironmentItem
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
