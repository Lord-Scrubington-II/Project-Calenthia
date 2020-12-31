using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedComp : IComparer<GenericActor>
{
    public int Compare(GenericActor x, GenericActor y)
    {
        int comp = x.GetTrueSpeed() - y.GetTrueSpeed();
        if (comp == 0)
            return x.GetHashCode() - y.GetHashCode();
        return comp;
    }
}
