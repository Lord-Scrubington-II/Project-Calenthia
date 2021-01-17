using System;

public class MDefUp : BuffDebuff
{

    //Constructor initializing fields 
    public MDefUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "MDefUp";
        ChangeMod.changeMDef(a, 10);
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override void resolve(GenericActor a)
    {
        //NOTE: This is a very arbitrary designation subject to change
        ChangeMod.changeMDef(a, -10);
    }
}