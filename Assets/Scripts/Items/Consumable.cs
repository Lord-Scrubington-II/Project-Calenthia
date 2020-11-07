using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : GenericItem
{
    public abstract void Apply(GenericActor user);
}
