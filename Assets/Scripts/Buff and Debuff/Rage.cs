public class Rage:BuffDebuff 
{

    //Constructor initializing fields 
    public Rage(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "Rage";
        buffElements = new int[3];
        initial();
    }

    //Double Attack Half Defense
    public override int initial()
    {
        buffElements[0] = ChangeMod.changeAtk(actor, 100);
        buffElements[1] = ChangeMod.changeDef(actor, -50);
        buffElements[2] = ChangeMod.changeMDef(actor, -50);
        return duration;
    }

    public override int resolve()
    {
        actor.AtkMod += (int) buffElements[0];
        actor.DefMod += (int) buffElements[1];
        actor.MDefMod += (int) buffElements[2];
        return 0;
    }
}




