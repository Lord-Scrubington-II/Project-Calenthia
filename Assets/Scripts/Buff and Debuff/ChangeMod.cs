//using System.Runtime.Remoting.Messaging; nani?
using UnityEngine;
using System;

/**
* Manage buffs and debuffs 
*/

public abstract class ChangeMod : GenericStatusEffect
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
}