//using System.Runtime.Remoting.Messaging; nani?
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class GenericStatusEffect
{
    //Duration of the buff or debuff 
    protected int duration;

    //exists for method overloading. some status effects won't need to take params, maybe.
    //uncomment and implement as seen fit.
    //public abstract void execute(GenericActor actor);
}