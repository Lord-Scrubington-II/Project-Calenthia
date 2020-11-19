using System;

public class MDefUp : BuffDebuff
{

    //Constructor initializing fields 
    public MDefUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "MDefUp";
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a)
    {
        //NOTE: This is a very arbitrary designation subject to change
        ChangeMod.changeMDef(a, 10);
        this.duration--;
        return this.duration;
    }
}