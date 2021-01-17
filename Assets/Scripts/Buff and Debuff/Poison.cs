using System;

public class Poison : BuffDebuff
{

    //Constructor initializing fields 
    public Poison(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "Poison";
    }

    //Detract hp
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a)
    {
        //Poison will do 5% of total health per turn 
        //TODO: Change if too punishing or not enough 
        ChangeMod.changeHp(a, -5);
        return base.execute(a);
    }
}