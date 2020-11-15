using System;

public class Poison : BuffDebuff
{

    //Constructor initializing fields 
    public Poison(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
    }

    //Detract hp
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a, int percentChange)
    {
        ChangeMod.changeHp(a, percentChange);
        this.duration--;
        return this.duration;
    }
}