using UnityEngine;
using System;

/**
 * All buffs/debuffs regarding a change in health 
 */
public class ModHp : ChangeMod
{
    private const int CONVERTER = 100;

    public override int execute(GenericActor actor, int percentChange, int dur)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //NOTE: Since hp is unsigned, this conversion from uint to an int can 
        //throw an overflow exception 
        int actorHp = Convert.ToInt32(actor.CurrentHP);

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actorHp), MidpointRounding.AwayFromZero));

        int intNewHp = actorHp - statMod;

        //Convert newHp back to uint 
        uint uintNewHp;
        if (intNewHp <= 0)
        {
            uintNewHp = 0;
        }
        else
        {
            uintNewHp = Convert.ToUInt32(intNewHp);
        }

        //Update
        //Note that duration can become negative. 
        actor.CurrentHP = uintNewHp;
        this.duration = --dur;
        return dur;
    }
}