using System;

public class AllDefUp : BuffDebuff
{

    //Constructor initializing fields 
    public AllDefUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "AllDefUp";
        buffElements = new int[2];
        initial();
    }

    public override int initial()
    {
        buffElements[0] = ChangeMod.changeMDef(actor, 5);
        buffElements[1] = ChangeMod.changeDef(actor, 5);
        return duration;
    }

    public override int resolve()
    {
        actor.MDefMod -= buffElements[0];
        actor.DefMod -= buffElements[1];
        return 0;
    }
}