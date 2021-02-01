using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Abstract: <c>GenericActor</c>
/// All participant entities in battle are Generic Actors. This includes party members and enemies.
/// Generic Actors have Health Points, Magic Points, Statistics, and a list of Skills.
/// </summary>
public abstract class GenericActor : ScriptableObject, System.IComparable
{
    [Header("HP and MP")]
    [SerializeField] private int hpMax;
    [SerializeField] private int mpMax;
    [SerializeField] private int healthPoints;
    [SerializeField] private int magicPoints;
    protected List<GenericSkill> skills = new List<GenericSkill>();
    protected List<BuffDebuff> statusEffects = new List<BuffDebuff>();
    private HashSet<BuffDebuff> statusImmunities = new HashSet<BuffDebuff>();
    private Dictionary<GenericSkill.DamageTypes, float> weakResist = new Dictionary<GenericSkill.DamageTypes, float>();
    [SerializeField] private bool isDead = false;
    [SerializeField] private int level; //do not change this! eventually it will no longer be serialized, and instead viewable thru UI

    /// <summary>
    /// Struct: <c>StatisticsBlock</c> 
    /// This struct contains the stats of the Generic Actor.
    /// </summary>
    [System.Serializable]
    public struct StatisticsBlock
    {
        //I could have simply made GenericActors possess a 6-element array of unsigned ints, 
        //but this method allows for a more readable, abstract approach to stat manipulation (i.e. syntactic sugar)

        [SerializeField] private int attack;
        [SerializeField] private int magicAttack;
        [SerializeField] private int defense;
        [SerializeField] private int magicDefense;
        [SerializeField] private int speed;
        [SerializeField] private int luck;

        public StatisticsBlock(int atk, int mAtk, int def, int mDef, int spd, int luk)
        {
            attack = atk;
            magicAttack = mAtk;
            defense = def;
            magicDefense = mDef;
            speed = spd;
            luck = luk;
        }

        /// <summary>
        /// Method: <c>ModAllStats</c> 
        /// To be called on level-up event, etc. For declaring /permanent/ changes to a Generic Actor's stats block.
        /// </summary>
        public void ModAllStats(int atk, int mAtk, int def, int mDef, int spd, int luk)
        {
            Attack += atk;
            MagicAttack += mAtk;
            Defense += def;
            MagicDefense += mDef;
            Speed += spd;
            Luck += luk;
        }

        /// <summary>
        /// Method: <c>ListAllStats</c> 
        /// Returns a list of the actor's stats as ints in the order of their declaration.
        /// </summary>
        public List<int> ListAllStats()
        {
            List<int> stats = new List<int>();
            stats.Add(attack);
            stats.Add(defense);
            stats.Add(magicAttack);
            stats.Add(magicDefense);
            stats.Add(speed);
            stats.Add(luck);
            return stats;
        }

        public int Attack { get => attack; set => attack = value; }
        public int MagicAttack { get => magicAttack; set => magicAttack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int MagicDefense { get => magicDefense; set => magicDefense = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Luck { get => luck; set => luck = value; }
    }

    [SerializeField] private StatisticsBlock stats;

    [SerializeField] private StatisticsBlock mods;
    [SerializeField] private int hpMod; //Not in statisticsblock



    public int Level { get => level; protected set => level = value; }

    /// <summary>
    /// Struct: <c>StatisticsBlock</c> 
    /// This struct contains information about the Generic Actor's standard attack.
    /// </summary>
    public struct StandardAttackData
    {

    }


    //HP & MP
    public int CurrentHP { get => healthPoints; set => healthPoints = value; }
    public int CurrentMP { get => magicPoints; set => magicPoints = value; }
    public int HPMax { get => hpMax; protected set => hpMax = value; }
    public int MPMax { get => mpMax; protected set => mpMax = value; }

    //properties on the Statistics Block
    public StatisticsBlock AllStats { get => stats; protected set => stats = value; }
    public int Attack { get => stats.Attack; protected set => stats.Attack = value; }
    public int Defense { get => stats.Defense; protected set => stats.Defense = value; }
    public int MagicAttack { get => stats.MagicAttack; protected set => stats.MagicAttack = value; }
    public int MagicDefense { get => stats.MagicDefense; protected set => stats.MagicDefense = value; }
    public int Speed { get => stats.Speed; protected set => stats.Speed = value; }
    public int Luck { get => stats.Luck; protected set => stats.Luck = value; }

    //properties on the mods
    public StatisticsBlock AllMods { get => mods; protected set => mods = value; }
    public int AtkMod { get => mods.Attack; set => mods.Attack = value; }
    public int DefMod { get => mods.Defense; set => mods.Defense = value; }
    public int MAtkMod { get => mods.MagicAttack; set => mods.MagicAttack = value; }
    public int MDefMod { get => mods.MagicDefense; set => mods.MagicDefense = value; }
    public int SpdMod { get => mods.Speed; set => mods.Speed = value; }
    public int LukMod { get => mods.Luck; set => mods.Luck = value; }
    public int HPMod { get => hpMod; set => hpMod = value; }

    //skills
    public List<GenericSkill> Skills { get => skills; set => skills = value; }
    public List<BuffDebuff> StatusEffects { get => statusEffects; set => statusEffects = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public Dictionary<GenericSkill.DamageTypes, float> WeakResist { get => weakResist; protected set => weakResist = value; }
    public HashSet<BuffDebuff> StatusImmunities { get => statusImmunities; protected set => statusImmunities = value; }

    //default behaviour for standard attack.
    public virtual int StandardAttack(GenericActor target)
    {
        int atk;
        int def;
        int damage;
        float resistanceFactor;

        atk = this.GetTrueAttack();
        def = target.GetTrueDefense();
        resistanceFactor = BattleElements.CombatManager.CalculateResistanceFactor(GenericSkill.DamageTypes.Physical, target);
        damage = (int)(resistanceFactor * BattleElements.CombatManager.CalculateDamage(atk, def));

        target.CurrentHP -= damage;

        return damage;
    }

    public void Defend()
    {
        //TODO: Apply buff "defending" to the caller
    }
    public abstract void Flee();
    public abstract int UseSkill(GenericSkill skill);

    public void Kill()
    {
        IsDead = true;
    }

    public void Revive()
    {
        IsDead = false;
    }

    //IComparable Implementation
    public int CompareTo(object other)
    {
        if (other.GetType() != typeof(GenericActor))
        {
            throw new System.Exception("REEEEEEEEE gimme an Actor!!!11!!");
        }

        if (this.Speed == ((GenericActor)other).Speed)
        {
            return 0;
        }
        else if (this.Speed > ((GenericActor)other).Speed)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    //TODO handle status immunities...
    public bool attachStatusEffect(BuffDebuff status)
    {
        if (StatusEffects.Contains(status)){
            return false;
        } 
        else
        {
            this.StatusEffects.Add(status);
            return true;
        }
    }

    //TODO handle status immunities...
    public int attachStatusEffect(List<BuffDebuff> statuses)
    {
        int successes = 0;
        foreach(BuffDebuff status in statuses)
        {
            if (!StatusEffects.Contains(status))
            {
                this.StatusEffects.Add(status);
                successes++;
            }
        }
        return successes;
    }

    //Get True Stat Methods
    public virtual int GetTrueAttack()
    {
        return Attack + AtkMod;
    }
    public virtual int GetTrueDefense()
    {
        return Defense + DefMod;
    }
    public virtual int GetTrueMagicAttack()
    {
        return MagicAttack + MAtkMod;
    }
    public virtual int GetTrueMagicDefense()
    {
        return MagicDefense + MDefMod;
    }
    public virtual int GetTrueSpeed()
    {
        return Speed + SpdMod;
    }
    public virtual int GetTrueLuck()
    {
        return Luck + LukMod;
    }
    public virtual int GetTrueHPMax()
    {
        return HPMax + HPMod;
    }
}
