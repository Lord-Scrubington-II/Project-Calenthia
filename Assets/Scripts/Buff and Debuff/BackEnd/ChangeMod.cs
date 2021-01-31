using UnityEngine;
using System;

/**
* Manage buffs and debuff creation 
*/

public class ChangeMod
{
    //Constant for converting percentages 
    private const int CONVERTER = 100;


    public static int changeAtk(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Attack), MidpointRounding.AwayFromZero));

        //Update
        actor.AtkMod += statMod;

        return statMod;
    }

    public static int changeSpeed(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Speed), MidpointRounding.AwayFromZero));

        //Update
        actor.SpdMod += statMod;

        return statMod;
    }

    public static int changeLuck(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Luck), MidpointRounding.AwayFromZero));

        //Update
        actor.LukMod += statMod;

        return statMod;
    }

    public static int changeMAtk(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.MagicAttack), MidpointRounding.AwayFromZero));

        //Update
        actor.MAtkMod += statMod;

        return statMod;
    }

    public static int changeMDef(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.MagicDefense), MidpointRounding.AwayFromZero));

        //Update
        actor.MDefMod += statMod;

        return statMod;
    }

    public static int changeDef(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Defense), MidpointRounding.AwayFromZero));

        //Update
        actor.DefMod += statMod;

        return statMod;
    }
    
    public static int changeHp(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //NOTE: Since hp is unsigned, this conversion from int to an int can 
        //throw an overflow exception 
        int actorHp = actor.HPMax;

        //Round the stat change
        int statMod = (int)Math.Round((percentVal * actorHp), MidpointRounding.AwayFromZero);

        //Update
        actor.HPMod += statMod;

        return statMod;
    }

    public static int healordmg(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //NOTE: Since hp is unsigned, this conversion from int to an int can 
        //throw an overflow exception 
        int actorHp = actor.GetTrueHPMax();

        //Round the stat change
        int statMod = (int)Math.Round((percentVal * actorHp), MidpointRounding.AwayFromZero);

        int intNewHp = actor.CurrentHP - statMod;

        // Prevent weird unsigned conversion of negative number 
        if (intNewHp <= 0)
        {
            intNewHp = 0;
        }

        //Update
        actor.CurrentHP = intNewHp;

        return statMod;
    }

}