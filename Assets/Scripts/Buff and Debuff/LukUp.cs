using System;

public class LukUp : BuffDebuff
{

    //Constructor initializing fields 
    public LukUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "LukUp";
        buffElements = new int[1];
    }

    public override int initial()
    {
        buffElements[0] = ChangeMod.changeLuck(actor, 10);
        return duration;
    }

    public override int resolve()
    {
        actor.LukMod -= buffElements[0];
        return 0;
    }
}