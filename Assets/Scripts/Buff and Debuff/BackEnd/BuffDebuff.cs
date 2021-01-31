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
    /// The dmg dealt, 0 if none
    /// </returns>
    /// 
    public virtual int execute()
    {
        if (duration == 0)
            return resolve();
        this.duration--;
        return 0;
    }
    
    //The inital application of the buff, stat changes etc. Returns the duration.
    public virtual int initial()
    {
        return duration;
    }

    //Resolves the end of buff, return any dmg caused if any.
    public virtual int resolve()
    {
        return 0;
    }
    //Duration of the buff or debuff 
    public int duration;
    public GenericActor actor;
    public int[] buffElements; //Elements that the buff needs to keep track of like stat changes, etc for the buff to resolve.
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