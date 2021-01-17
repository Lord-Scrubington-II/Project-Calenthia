using System;

public class SpeedUp : BuffDebuff
{

    //Constructor initializing fields 
    public SpeedUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "SpeedUp";
        ChangeMod.changeSpeed(a, 10);
    }

    public override void resolve(GenericActor a)
    {
        ChangeMod.changeSpeed(a, -10);
    }
}