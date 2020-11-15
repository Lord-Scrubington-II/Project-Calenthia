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
    }

    public override int InvokeSkill()
    {
        return 0;
    }
}
