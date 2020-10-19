﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract: <c>GenericActor</c>
/// All participant entities in battle are Generic Actors. This includes party members and enemies.
/// Generic Actors have Health Points, Magic Points, Statistics, and a list of Skills.
/// </summary>
public abstract class GenericActor : MonoBehaviour
{
    private uint hpMax;
    private uint mpMax;
    private uint healthPoints;
    private uint magicPoints;
    private List<GenericSkill> skills;
    private Sprite sprite;

    /// <summary>
    /// Struct: <c>StatisticsBlock</c> 
    /// This struct contains the stats of the Generic Actor.
    /// </summary>
    public struct StatisticsBlock
    {
        //I could have simply made GenericActors possess a 6-element array of unsigned ints, 
        //but this method allows for a more readable, abstract approach to stat manipulation (i.e. syntactic sugar)
        private uint attack;
        private uint mAttack;
        private uint defense;
        private uint mDefense;
        private uint speed;
        private uint luck;

        public StatisticsBlock(uint atk, uint mAtk, uint def, uint mDef, uint spd, uint luk)
        {
            attack = atk;
            mAttack = mAtk;
            defense = def;
            mDefense = mDef;
            speed = spd;
            luck = luk;
        }

        /// <summary>
        /// Method: <c>ModAllStats</c> 
        /// To be called on level-up event, etc. For declaring permanent changes to a Generic Actor's stats block.
        /// </summary>
        public void ModAllStats(uint atk, uint mAtk, uint def, uint mDef, uint spd, uint luk)
        {
            Attack += atk;
            MAttack += mAtk;
            Defense += def;
            MDefense += mDef;
            Speed += spd;
            Luck += luk;
        }
        public uint Attack { get => attack; set => attack = value; }
        public uint MAttack { get => mAttack; set => mAttack = value; }
        public uint Defense { get => defense; set => defense = value; }
        public uint MDefense { get => mDefense; set => mDefense = value; }
        public uint Speed { get => speed; set => speed = value; }
        public uint Luck { get => luck; set => luck = value; }
    }

    private StatisticsBlock stats;

    public uint CurrentHP { get => healthPoints; set => healthPoints = value; }
    public uint CurrentMP { get => magicPoints; set => magicPoints = value; }
    public uint HPMax { get => hpMax; private set => hpMax = value; }
    public uint MPMax { get => mpMax; private set => mpMax = value; }

    public StatisticsBlock AllStats { get => stats; private set => stats = value; }
    public uint Attack { get => stats.Attack; private set => stats.Attack = value; }
    public uint Defense { get => stats.Defense; private set => stats.Defense = value; }
    public uint MAttack { get => stats.MAttack; private set => stats.MAttack = value; }
    public uint MDefense { get => stats.MDefense; private set => stats.MDefense = value; }
    public uint Speed { get => stats.Speed; private set => stats.Speed = value; }
    public uint Luck { get => stats.Luck; private set => stats.Luck = value; }

    public abstract void StandardAttack(GenericActor target);
    public abstract void Defend();
    public abstract void UseItem(GenericItem item);
    public abstract void MoveToPosition(byte loc);
    public abstract void Flee();
    public abstract void UseSkill(GenericSkill skill);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}