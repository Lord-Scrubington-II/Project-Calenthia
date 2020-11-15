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
    private List<GenericSkill> skills;
    private List<BuffDebuff> statusEffects;
    [SerializeField] private bool isDead = false;
    [SerializeField] private int level; //do not change this! eventually it will no longer be serialized, and instead viewable thru UI

    [Header("Temporary Stat Modifications")]
    [SerializeField] private int atkMod;
    [SerializeField] private int defMod;
    [SerializeField] private int mAtkMod;
    [SerializeField] private int mDefMod;
    [SerializeField] private int spdMod;
    [SerializeField] private int lukMod;

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

    //stat mods
    public int AtkMod { get => atkMod; set => atkMod = value; }
    public int DefMod { get => defMod; set => defMod = value; }
    public int MAtkMod { get => mAtkMod; set => mAtkMod = value; }
    public int MDefMod { get => mDefMod; set => mDefMod = value; }
    public int SpdMod { get => spdMod; set => spdMod = value; }
    public int LukMod { get => lukMod; set => lukMod = value; }

    //skills
    public List<GenericSkill> Skills { get => skills; set => skills = value; }
    public List<BuffDebuff> StatusEffects { get => statusEffects; private set => statusEffects = value; }

    //abstract combat methods
    public abstract int StandardAttack();
    public void Defend()
    {
        //TODO: Apply buff "defending" to the caller
    }
    public abstract void Flee();
    public abstract int UseSkill(GenericSkill skill);

    public void Kill()
    {
        isDead = true;
    }

    public void Revive()
    {
        isDead = false;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
