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
        buffElements = new int[2];
        initial();
    }

    public override int initial()
    {
        //NOTE: This is a very arbitrary designation subject to change
        //Kill off actor raise atk by 50%
        buffElements[0] = ChangeMod.changeAtk(actor, 50);
        buffElements[1] = ChangeMod.changeMAtk(actor, 50);

        return duration;
    }

    public override int resolve()
    {
        actor.AtkMod -= (int) buffElements[0];
        actor.MAtkMod -= (int) buffElements[1];
        return (-1) * ChangeMod.changeHp(actor, -100);
    }
}