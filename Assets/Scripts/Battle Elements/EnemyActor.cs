using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleElements
{
    public abstract class EnemyActor : GenericActor
    {
        GenericItem heldItem;
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

        public abstract void determineHeldItem();
    }
}