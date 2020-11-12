namespace BattleElements
{
    internal class EnemyActor : GenericActor
    {
        public override void Flee()
        {
            //initiate flee sequence for this actor only
        }

        public override int StandardAttack()
        {
            throw new System.NotImplementedException();
        }
        public override void UseSkill(GenericSkill skill)
        {
            throw new System.NotImplementedException();
        }
    }
}