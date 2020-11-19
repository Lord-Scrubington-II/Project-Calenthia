using System;

public class LukUp : BuffDebuff
{

    //Constructor initializing fields 
    public LukUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "LukUp";
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a)
    {
        //NOTE: This is a very arbitrary designation subject to change
        ChangeMod.changeLuck(a, 10);
        this.duration--;
        return this.duration;
    }
}