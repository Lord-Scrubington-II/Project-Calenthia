using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Utilize the Mod... classes to create buffs and debuffs which affect 
/// several stats at once 
/// </summary>
public abstract class BuffDebuff
{
    /// <summary>
    /// Method: Handles the debuff or buff change in stats
    /// </summary>
    /// <param name="a"> The actor which this will applied</param>
    /// <returns>
    /// The duration of the debuff or buff after execution
    /// </returns>
    public abstract int execute();
    public abstract int initial();
    public abstract int resolve();

    //Duration of the buff or debuff 
    public int duration;
    public GenericActor actor;
    //Mainly just for HashCode() 
    public String name; 

    public override bool Equals(object bdebuff)
    {
        //Check null and valid type 
        if (bdebuff == null || (!(bdebuff is BuffDebuff)))
        {
            return false;
        }

        //Comparison by type 
        bool isEqual = this.GetType() == bdebuff.GetType();
        return isEqual;
    }

    //Not necessary, but hashCode() override just in case 
    public override int GetHashCode()
    {
        //name is null hash is 0 else, name.GetHashCode
        return (this.name != null ? this.name.GetHashCode() : 0);
    }
}