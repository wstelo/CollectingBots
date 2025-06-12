using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Antlr3.Runtime.Tree.TreeWizard;

public interface IResoursable
{
    public void Accept(IVisitor visitor);
    public void CollectedObject();
}
