using System;

public class DefUp : BuffDebuff
{

    //Constructor initializing fields 
    public DefUp(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "DefUp";
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a)
    {
        //NOTE: This is a very arbitrary designation subject to change
        ChangeMod.changeDef(a, 10);
        this.duration--;
        return this.duration;
    }
}