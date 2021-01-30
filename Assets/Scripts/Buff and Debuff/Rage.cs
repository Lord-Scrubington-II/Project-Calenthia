public class Rage:BuffDebuff 
{

    //Constructor initializing fields 
    public Rage(int dur, GenericActor a)
    {
        this.duration = dur;
        this.actor = a;
        this.name = "Rage";
    }

    //double attack half defense 
    //param a: The actor to which this will be applied
    public override int execute(GenericActor a)
    {
        ChangeMod.changeAtk(a, 100);
        ChangeMod.changeDef(a, -50);
        ChangeMod.changeMDef(a, -50); 
        this.duration--;
        return this.duration;
    }

    public override int execute()
    {
        throw new System.NotImplementedException();
    }

    public override int initial()
    {
        throw new System.NotImplementedException();
    }

    public override int resolve()
    {
        throw new System.NotImplementedException();
    }
}




