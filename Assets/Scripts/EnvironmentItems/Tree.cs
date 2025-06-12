using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Tree : EnvironmentItem
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
