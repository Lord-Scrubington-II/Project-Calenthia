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

        public enum ActionTypes { 
            StandardAttack,
            Defend,
            Flee,
            Skill,
            ShiftPosition
        }

        public int BreakGauge { get => breakGauge; protected set => breakGauge = value; }
        public int BreakGaugeMax { get => breakGaugeMax; protected set => breakGaugeMax = value; }

        public override void Flee()
        {
            //initiate flee sequence for this actor only
        }
        
        //gacha go brrrrrr
        public abstract void DetermineHeldItem();

        //AI Methods
        public abstract ActionTypes SelectAction();

        public abstract GenericActor SelectTarget();
    }
}