using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : GenericSkill
{

    private void Awake()
    {
        //init target data
        IsPercentSkill = false;
        TargetsSelfOnly = false;
        DamageType = DamageTypes.Fire;
        TargetsGroup = TargetGroup.Single;
        TargetsType = TargetType.Enemies;
        
        //init effect data
        NumHits = 1;
        BaseEffectFactor = 3f;
        BaseAccuracy = 100;
        BaseBreakDamage = 50;
        EffectPercent = 0;
        //StatusInflictedToTarget[new Burn()] = 0.2f;
    }

    //technically we don't even need this.
    public override void InvokeSkill(GenericActor caster, List<GenericActor> targets)
    {
        base.InvokeSkill(caster, targets);
    }
}
