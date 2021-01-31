using System;

public class MDefUp : BuffDebuff
{

    //Constructor initializing fields 
    public MDefUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "MDefUp";
        buffElements = new int[1];
        initial();
    }

    //Regen hp
    //param a: The actor to which this will be applied

    public override int initial()
    {
        buffElements[0] = ChangeMod.changeMDef(actor, 10);
        return duration;
    }

    public override int resolve()
    {
        actor.MDefMod -= buffElements[0];
        return 0;
    }
}