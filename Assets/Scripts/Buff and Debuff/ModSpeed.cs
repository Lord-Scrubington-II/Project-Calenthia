using UnityEngine;
using System;

/**
 * All buffs/debuffs regarding a change in speed
 */
public class ModSpeed : ChangeMod
{
    private const int CONVERTER = 100;

    public override int execute(GenericActor actor, int percentChange, int dur)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.SpdMod), MidpointRounding.AwayFromZero));

        //Update
        //Note that duration can be negative
        actor.SpdMod = statMod;
        this.duration = --dur;
        return dur;
    }
}