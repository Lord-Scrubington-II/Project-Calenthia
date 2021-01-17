using System;

public class Regen : BuffDebuff
{

    //Constructor initializing fields 
    public Regen(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "Regen";
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a)
    {
        //Heal will do 7 percent total hp per turn 
        ChangeMod.changeHp(a, 7);
        return base.execute(a);
    }
}