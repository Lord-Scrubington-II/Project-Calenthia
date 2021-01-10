using System;

public class AllDefUp : BuffDebuff
{

    //Constructor initializing fields 
    public AllDefUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "AllDefUp";
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int initialize(GenericActor a)
    {
        //NOTE: This is a very arbitrary designation subject to change
        ChangeMod.changeMDef(a, 5);
        ChangeMod.changeDef(a, 5);
        this.duration--;
        return this.duration;
    }
}