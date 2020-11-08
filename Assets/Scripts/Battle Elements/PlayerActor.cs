using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerActor : GenericActor
{
    
    GenericItem weapon;
    protected bool isMartial;

    public GrowthRateMatrix AllGrowthRates { get => growthRates; protected set => growthRates = value; }

    [System.Serializable]
    public struct GrowthRateMatrix
    {
        [SerializeField] private uint hp;
        [SerializeField] private uint mp;
        [SerializeField] private uint attack;
        [SerializeField] private uint mAttack;
        [SerializeField] private uint defense;
        [SerializeField] private uint mDefense;
        [SerializeField] private uint speed;
        [SerializeField] private uint luck;


        public GrowthRateMatrix(uint HP, uint MP, uint atk, uint mAtk, uint def, uint mDef, uint spd, uint luk)
        {
            hp = HP;
            mp = MP;
            attack = atk;
            mAttack = mAtk;
            defense = def;
            mDefense = mDef;
            speed = spd;
            luck = luk;
        }


        public uint AttackGrowth { get => attack; set => attack = value; }
        public uint MAttackGrowth { get => mAttack; set => attack = value; }
        public uint DefenseGrowth { get => defense; set => attack = value; }
        public uint MDefenseGrowth { get => mDefense; set => attack = value; }
        public uint SpeedGrowth { get => speed; set => attack = value; }
        public uint LuckGrowth { get => luck; set => attack = value; }
        public uint HPGrowth { get => hp; set => hp = value; }
        public uint MPGrowth { get => mp; set => mp = value; }
    }

    [SerializeField] private GrowthRateMatrix growthRates;

    public override void Flee()
    {
        //flee based on speed of caller, 
        //base chance to flee is determined by differential between level of invoker and level of enemy.
        //invoke scenemanager if the flee check passes
    }

    /*
    public override void UseSkill(GenericSkill skill)
    {

    }
    */

    public void LevelUp()
    {
        uint HPMaxDelta = AllGrowthRates.HPGrowth;
        uint MPMaxDelta = AllGrowthRates.MPGrowth;
        uint ATKDelta = AllGrowthRates.AttackGrowth;
        uint MATKDelta = AllGrowthRates.MAttackGrowth;
        uint DEFDelta = AllGrowthRates.DefenseGrowth;
        uint MDEFDelta = AllGrowthRates.MDefenseGrowth;
        uint SPDDelta = AllGrowthRates.SpeedGrowth;
        uint LUKDelta = AllGrowthRates.LuckGrowth;

        this.AllStats.ModAllStats(ATKDelta, MATKDelta, DEFDelta, MDEFDelta, SPDDelta, LUKDelta);
        this.HPMax = HPMaxDelta;
        this.MPMax = MPMaxDelta;
        this.Level++;
    }
}
