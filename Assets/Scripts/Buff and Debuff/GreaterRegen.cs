using System;

public class GreaterRegen : BuffDebuff
{

    //Constructor initializing fields 
    public GreaterRegen(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "GreaterRegen";
        buffElements = new int[1] { 15 };
        initial();
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int execute()
    {
        base.execute();
        //Heal will do 15 percent total hp per turn 
        return (-1) * ChangeMod.changeHp(actor, buffElements[0]);
    }
}