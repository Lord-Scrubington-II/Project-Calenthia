public class Rage:BuffDebuff 
{

    //Constructor initializing fields 
    public Rage(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
    }

    //double attack half defense 
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a, int percentChange)
    {
        ChangeMod.changeAtk(a, 100);
        ChangeMod.changeDef(a, -50);
        ChangeMod.changeMDef(a, -50); 
        this.duration--;
        return this.duration;
    }
}




