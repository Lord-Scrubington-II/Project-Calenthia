using UnityEngine;
using System;

/**
* Manage buffs and debuff creation 
*/

public class ChangeMod
{
    //Constant for converting percentages 
    private const int CONVERTER = 100;


    public static void changeAtk(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Attack), MidpointRounding.AwayFromZero));

        //Update
        actor.AtkMod += statMod;
    }

    public static void changeSpeed(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Speed), MidpointRounding.AwayFromZero));

        //Update
        actor.SpdMod += statMod;
    }

    public static void changeLuck(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Luck), MidpointRounding.AwayFromZero));

        //Update
        actor.LukMod += statMod;
    }

    public static void changeMAtk(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.MagicAttack), MidpointRounding.AwayFromZero));

        //Update
        actor.MAtkMod += statMod;
    }

    public static void changeMDef(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.MagicDefense), MidpointRounding.AwayFromZero));

        //Update
        actor.MDefMod += statMod;
    }

    public static void changeDef(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //Round the stat change
        int statMod = (int)(Math.Round((percentVal * actor.Defense), MidpointRounding.AwayFromZero));

        //Update
        actor.DefMod = statMod;
    }

    public static void changeHp(GenericActor actor, int percentChange)
    {
        //Retrieve percent val 
        double percentVal = (percentChange) / 100;

        //NOTE: Since hp is unsigned, this conversion from int to an int can 
        //throw an overflow exception 
        int actorHp = actor.CurrentHP;

        //Round the stat change
        int statMod = (int)Math.Round((percentVal * actorHp), MidpointRounding.AwayFromZero);

        int intNewHp = actorHp - statMod;

        // Prevent weird unsigned conversion of negative number 
        if (intNewHp <= 0)
        {
            intNewHp = 0; 
        }

        //Update
        actor.CurrentHP = intNewHp;
    }
}