using System;

public class SpeedUp : BuffDebuff
{

    //Constructor initializing fields 
    public SpeedUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "SpeedUp";
        buffElements = new int[1];
        initial();
    }

    public override int initial()
    {
        buffElements[0] = ChangeMod.changeSpeed(actor, 10);
        return duration;
    }

    public override int resolve()
    {
        actor.SpdMod -= (int) buffElements[0];
        return 0;
    }
}