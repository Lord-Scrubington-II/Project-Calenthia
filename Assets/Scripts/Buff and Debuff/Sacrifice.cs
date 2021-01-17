using System;

/**
 * Greatly raise Atk stat and die following turn 
 * Seems more like a skill in retrospect 
 */
public class Sacrifice : BuffDebuff
{

    //Constructor initializing fields 
    public Sacrifice(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "Sacrifice";
    }

    //Regen hp
    //param a: The actor to which this will be applied
    public override int initialize(GenericActor a)
    {
        //NOTE: This is a very arbitrary designation subject to change
        //Kill off actor raise atk by 50%
        ChangeMod.changeHp(a, -100);
        ChangeMod.changeAtk(a, 50);
        ChangeMod.changeMAtk(a, 50);
        this.duration--;
        return this.duration;
    }
}