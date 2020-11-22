using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerActor : GenericActor
{

    private Weapon weapon;
    private Armor armour;
    private EquippableItem trinket;
    protected bool isMartial;

    [System.Serializable]
    public struct GrowthRateMatrix
    {
        [SerializeField] private int hp;
        [SerializeField] private int mp;
        [SerializeField] private int attack;
        [SerializeField] private int mAttack;
        [SerializeField] private int defense;
        [SerializeField] private int mDefense;
        [SerializeField] private int speed;
        [SerializeField] private int luck;


        public GrowthRateMatrix(int HP, int MP, int atk, int mAtk, int def, int mDef, int spd, int luk)
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


        public int AttackGrowth { get => attack; set => attack = value; }
        public int MAttackGrowth { get => mAttack; set => attack = value; }
        public int DefenseGrowth { get => defense; set => attack = value; }
        public int MDefenseGrowth { get => mDefense; set => attack = value; }
        public int SpeedGrowth { get => speed; set => attack = value; }
        public int LuckGrowth { get => luck; set => attack = value; }
        public int HPGrowth { get => hp; set => hp = value; }
        public int MPGrowth { get => mp; set => mp = value; }
    }

    [SerializeField] private GrowthRateMatrix growthRates;

    public GrowthRateMatrix AllGrowthRates { get => growthRates; protected set => growthRates = value; }
    public Weapon EquippedWeapon { get => weapon; set => weapon = value; }
    public Armor EquippedArmour { get => armour; set => armour = value; }
    public EquippableItem EquippedTrinket { get => trinket; set => trinket = value; }

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
        int HPMaxDelta = AllGrowthRates.HPGrowth;
        int MPMaxDelta = AllGrowthRates.MPGrowth;
        int ATKDelta = AllGrowthRates.AttackGrowth;
        int MATKDelta = AllGrowthRates.MAttackGrowth;
        int DEFDelta = AllGrowthRates.DefenseGrowth;
        int MDEFDelta = AllGrowthRates.MDefenseGrowth;
        int SPDDelta = AllGrowthRates.SpeedGrowth;
        int LUKDelta = AllGrowthRates.LuckGrowth;

        this.AllStats.ModAllStats(ATKDelta, MATKDelta, DEFDelta, MDEFDelta, SPDDelta, LUKDelta);
        this.HPMax = HPMaxDelta;
        this.MPMax = MPMaxDelta;
        this.Level++;
    }

    public abstract void LoadLevelOneStats();

    public void PostBattleCleanUp()
    {
        AtkMod = 0;
        MAtkMod = 0;
        DefMod = 0;
        MDefMod = 0;
        SpdMod = 0;
        LukMod = 0;
        StatusEffects.Clear();
        if (this.IsDead)
        {
            this.CurrentHP = 1;
            this.IsDead = false;
        }
    }

    //use json utils to write fields to JSON
    public void Serialize()
    {

    }

    //Get True Stat Methods for player actors
    //These should be changed to incorporate the statistics provided by armour and weapons
    //to wit: weapon.attack; armour.defense
    //To be safe, all weapons and armour need to have fields for all stats. set them to 0 if it provides
    //no bonus for that stat.
    public override int GetTrueAttack()
    {
        return Attack + AtkMod + EquippedWeapon.atk + EquippedArmour.atk + EquippedTrinket.atk;
    }
    public override int GetTrueDefense()
    {
        return Defense + DefMod + EquippedWeapon.def + EquippedArmour.def + EquippedTrinket.def;
    }
    public override int GetTrueMagicAttack()
    {
        return MagicAttack + MAtkMod + EquippedWeapon.matk + EquippedArmour.matk + EquippedTrinket.matk;
    }
    public override int GetTrueMagicDefense()
    {
        return MagicDefense + MDefMod + EquippedWeapon.mdef + EquippedArmour.mdef + EquippedTrinket.mdef;
    }
    public override int GetTrueSpeed()
    {
        return Speed + SpdMod + EquippedWeapon.spd + EquippedArmour.spd + EquippedTrinket.spd;
    }
    public override int GetTrueLuck()
    {
        return Luck + LukMod + EquippedWeapon.luk + EquippedArmour.luk + EquippedTrinket.luk;
    }
}
