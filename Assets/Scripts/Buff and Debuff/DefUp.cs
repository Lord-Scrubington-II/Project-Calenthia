using System;

public class DefUp : BuffDebuff
{

    //Constructor initializing fields 
    public DefUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "DefUp";
        buffElements = new int[1];
        initial();
    }

    public override int initial()
    {
        buffElements[0] = ChangeMod.changeDef(actor, 10);
        return duration;
    }

    public override int resolve()
    {
        actor.DefMod -= (int) buffElements[0];
        return 0;
    }
}