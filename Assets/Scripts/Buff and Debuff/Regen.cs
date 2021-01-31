using System;

public class Regen : BuffDebuff
{

    //Constructor initializing fields 
    public Regen(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "Regen";
        buffElements = new int[1] { 7 };
        initial();
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int execute()
    {
        base.execute();

        //Heal will do 7 percent total hp per turn 
        return (-1) * ChangeMod.healordmg(actor, buffElements[0]);
    }
}