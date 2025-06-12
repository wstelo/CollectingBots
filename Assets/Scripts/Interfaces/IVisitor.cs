using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitor
{
    void Visit(Tree tree);
    void Visit(Stone stone);
    void Visit(Iron iron);
}
