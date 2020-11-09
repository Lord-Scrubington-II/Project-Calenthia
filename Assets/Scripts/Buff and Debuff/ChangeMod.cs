using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System;

/**
* Manage buffs and debuffs 
*/

public interface ChangeMod
{
    //Duration of the buff or debuff 
    int duration;

    /// <summary>
    /// Method: Handles the debuff or buff change in stats
    /// </summary>
    /// <param name="percentChange"> Negative or positive val between 0 - 100</param>
    /// <param name="a"> The actor which this will applied</param>
    /// <returns>
    /// The duration of the debuff or buff after execution
    /// </returns>
    abstract int execute(GenericActor a, int percentChange, int dur);
}