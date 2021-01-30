using System;

public class GreaterRegen : BuffDebuff
{

    //Constructor initializing fields 
    public GreaterRegen(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "GreaterRegen";
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a)
    {
        //Heal will do 15 percent total hp per turn 
        ChangeMod.changeHp(a, 15);
        this.duration--;
        return this.duration;
    }

    public override int execute()
    {
        throw new NotImplementedException();
    }

    public override int initial()
    {
        throw new NotImplementedException();
    }

    public override int resolve()
    {
        throw new NotImplementedException();
    }
}