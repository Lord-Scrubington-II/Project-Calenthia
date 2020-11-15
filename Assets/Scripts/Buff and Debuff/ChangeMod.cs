using UnityEngine;
using System;

/**
* Manage buffs and debuff creation 
*/

public abstract class ChangeMod
{
    //Constant for converting percentages 
    private const int CONVERTER = 100;


    public void changeAtk(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Attack), MidpointRounding.AwayFromZero));

        //Update
        //Note that duration can be negative
        actor.AtkMod = statMod;
    }

    public void changeSpeed(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Speed), MidpointRounding.AwayFromZero));

        //Update
        //Note that duration can be negative
        actor.SpdMod = statMod;
    }

    public void changeLuck(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Luck), MidpointRounding.AwayFromZero));

        //Update
        //Note that duration can be negative
        actor.LukMod = statMod;
    }

    public void changeMAtk(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.MagicAttack), MidpointRounding.AwayFromZero));

        //Update
        //Note that duration can be negative
        actor.MAtkMod = statMod;
    }

    public void changeMDef(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.MagicDefense), MidpointRounding.AwayFromZero));

        //Update
        //Note that duration can be negative
        actor.MDefMod = statMod;
    }

    public void changeDef(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Defense), MidpointRounding.AwayFromZero));

        //Update
        //Note that duration can be negative
        actor.DefMod = statMod;
    }

    public void changeHp(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //NOTE: Since hp is unsigned, this conversion from int to an int can 
        //throw an overflow exception 
        int actorHp = actor.CurrentHP;

        //Round the stat change
        int statMod = (int)Math.Round((percentVal * actorHp), MidpointRounding.AwayFromZero);

        int intNewHp = actorHp - statMod;

        //Update
        //Note that duration can become negative. 
        actor.CurrentHP = intNewHp;
    }
}