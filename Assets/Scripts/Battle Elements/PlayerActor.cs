using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerActor : GenericActor
{
    
    GenericItem weapon;
    private byte level;
    protected bool isMartial;
    private GrowthRateMatrix growthRates;

    public byte Level { get => level; set => level = value; }
    public GrowthRateMatrix AllGrowthRates { get => growthRates; set => growthRates = value; }

    public struct GrowthRateMatrix
    {
        private uint attack;
        private uint mAttack;
        private uint defense;
        private uint mDefense;
        private uint speed;
        private uint luck;

        public GrowthRateMatrix(uint atk, uint mAtk, uint def, uint mDef, uint spd, uint luk)
        {
            attack = atk;
            mAttack = mAtk;
            defense = def;
            mDefense = mDef;
            speed = spd;
            luck = luk;
        }

        public uint AttackGrowth { get => attack;}
        public uint MAttackGrowth { get => mAttack;}
        public uint DefenseGrowth { get => defense;}
        public uint MDefenseGrowth { get => mDefense;}
        public uint SpeedGrowth { get => speed;}
        public uint LuckGrowth { get => luck;}
    }

    public override void Flee()
    {
        //flee based on speed of caller, chance to flee is determined by differential between speed of invoker and enemy average
        //invoke scenemanager if the flee check passes
    }

    /*
    public override void UseSkill(GenericSkill skill)
    {

    }
    */

}
