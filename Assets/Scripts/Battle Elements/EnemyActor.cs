using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleElements
{
    public abstract class EnemyActor : GenericActor
    {
        GenericItem heldItem;
        private int breakGauge;
        private int breakGaugeMax;
        private List<GenericSkill.DamageTypes> weaknesses;
        private List<GenericSkill.DamageTypes> resistances;

        public int BreakGauge { get => breakGauge; protected set => breakGauge = value; }
        public int BreakGaugeMax { get => breakGaugeMax; protected set => breakGaugeMax = value; }

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