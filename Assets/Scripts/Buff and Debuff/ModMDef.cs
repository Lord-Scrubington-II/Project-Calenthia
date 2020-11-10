using UnityEngine;
using System;

/**
 * All buffs/debuffs regarding a change in mdef
 */
public class ModMDef : ChangeMod
{
    private const int CONVERTER = 100;

    public override int execute(GenericActor actor, int percentChange, int dur)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.MDefMod), MidpointRounding.AwayFromZero));

        //Update
        //Note that duration can be negative
        actor.MDefMod = statMod;
        this.duration = --dur;
        return dur;
    }

}