using System;

public class Poison : BuffDebuff
{

    //Constructor initializing fields 
    public Poison(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "Poison";
        buffElements = new int[1] { -5 };
        initial();
    }

    //Detract hp
    //param a: The actor to which this will be applied
    public override int execute()
    {
        //Poison will do 5% of total health per turn 
        //TODO: Change if too punishing or not enough 
        base.execute();
        return (-1) * ChangeMod.healordmg(actor, buffElements[0]);
    }
}