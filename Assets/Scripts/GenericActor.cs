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
    [SerializeField] private uint hpMax;
    [SerializeField] private uint mpMax;
    [SerializeField] private uint healthPoints;
    [SerializeField] private uint magicPoints;
    private List<GenericSkill> skills;
    [SerializeField] private bool isDead = false;
    [SerializeField] private int level;

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
        [SerializeField] private uint attack;
        [SerializeField] private uint magicAttack;
        [SerializeField] private uint defense;
        [SerializeField] private uint magicDefense;
        [SerializeField] private uint speed;
        [SerializeField] private uint luck;

        public StatisticsBlock(uint atk, uint mAtk, uint def, uint mDef, uint spd, uint luk)
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
        public void ModAllStats(uint atk, uint mAtk, uint def, uint mDef, uint spd, uint luk)
        {
            Attack += atk;
            MagicAttack += mAtk;
            Defense += def;
            MagicDefense += mDef;
            Speed += spd;
            Luck += luk;
        }
        public uint Attack { get => attack; set => attack = value; }
        public uint MagicAttack { get => magicAttack; set => magicAttack = value; }
        public uint Defense { get => defense; set => defense = value; }
        public uint MagicDefense { get => magicDefense; set => magicDefense = value; }
        public uint Speed { get => speed; set => speed = value; }
        public uint Luck { get => luck; set => luck = value; }
    }

    [SerializeField] private StatisticsBlock stats;
    public int Level { get => level; protected set => level = value; }


    //HP & MP
    public uint CurrentHP { get => healthPoints; set => healthPoints = value; }
    public uint CurrentMP { get => magicPoints; set => magicPoints = value; }
    public uint HPMax { get => hpMax; protected set => hpMax = value; }
    public uint MPMax { get => mpMax; protected set => mpMax = value; }

    //properties on the Statistics Block
    public StatisticsBlock AllStats { get => stats; protected set => stats = value; }
    public uint Attack { get => stats.Attack; protected set => stats.Attack = value; }
    public uint Defense { get => stats.Defense; protected set => stats.Defense = value; }
    public uint MagicAttack { get => stats.MagicAttack; protected set => stats.MagicAttack = value; }
    public uint MagicDefense { get => stats.MagicDefense; protected set => stats.MagicDefense = value; }
    public uint Speed { get => stats.Speed; protected set => stats.Speed = value; }
    public uint Luck { get => stats.Luck; protected set => stats.Luck = value; }

    //stat mods
    public int AtkMod { get => atkMod; set => atkMod = value; }
    public int DefMod { get => defMod; set => defMod = value; }
    public int MAtkMod { get => mAtkMod; set => mAtkMod = value; }
    public int MDefMod { get => mDefMod; set => mDefMod = value; }
    public int SpdMod { get => spdMod; set => spdMod = value; }
    public int LukMod { get => lukMod; set => lukMod = value; }

    //skills
    public List<GenericSkill> Skills { get => skills; protected set => skills = value; }

    //abstract combat methods
    public abstract int StandardAttack();
    public void Defend()
    {
        //TODO: Apply buff "defending" to the caller
    }
    public abstract void Flee();
    public abstract void UseSkill(GenericSkill skill);

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
        if(other.GetType() != typeof(GenericActor)){
            throw new System.Exception("REEEEEEEEE gimme an Actor!!!11!!");
        }

        if(this.Speed == ((GenericActor)other).Speed)
        {
            return 0;
        } else if (this.Speed > ((GenericActor)other).Speed)
        {
            return 1;
        } else
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
}