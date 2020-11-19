using System;

public class SpeedUp : BuffDebuff
{

    //Constructor initializing fields 
    public SpeedUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "SpeedUp";
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a)
    {
        //NOTE: This is a very arbitrary designation subject to change
        ChangeMod.changeSpeed(a, 10);
        this.duration--;
        return this.duration;
    }
}