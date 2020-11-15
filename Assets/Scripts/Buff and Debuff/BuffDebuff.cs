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
    /// <param name="percentChange"> Negative or positive val between 0 - 100</param>
    /// <param name="a"> The actor which this will applied</param>
    /// <returns>
    /// The duration of the debuff or buff after execution
    /// </returns>
    public abstract int execute(GenericActor a, int percentChange, int dur);

    //Duration of the buff or debuff 
    public int duration;

    public override bool Equals(object bdebuff)
    {
        //Just in case null for some reason 
        if (bdebuff == null)
        {
            return false;
        }

        //Ensure is of valid type 
        if (!(bdebuff is BuffDebuff))
        {
            return false;
        }

        //Comparison by type 
        bool isEqual = this.GetType() == bdebuff.GetType();
        return isEqual;
    }
}