using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : EnvironmentItem
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
