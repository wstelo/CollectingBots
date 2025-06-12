using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : EnvironmentItem
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
