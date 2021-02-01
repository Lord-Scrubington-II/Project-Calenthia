using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

namespace BattleElements
{

    public static class CombatManager
    {
        //Indices for positions in front and backlines
        static readonly byte LEFT = 0;
        static readonly byte CENTER = 1;
        static readonly byte RIGHT = 2;

        //Game State enum, to be used for determining the game's state
        public enum TurnState { PlayerTurn, EnemyTurn, }
        public static TurnState turnState;
        public enum BattleState{ BeforeTurn, DuringTurn, AfterTurn}
        public static BattleState battleState;

        public static PlayerActor[] playerParty;
        public static EnemyActor[] enemyFormation;
        public static PlayerActor[] playerFrontline;
        public static PlayerActor[] playerBackline;
        public static TurnTimeTable turntable;
        public static GenericActor myTurn;
  
        //Static Constructor for the static combat manager will be automatically called at the
        //first reference to it
        static CombatManager()
        {
            //Initializing All the fields
            playerParty = PartyData.PlayerParty;
            enemyFormation = EnemyData.Enemies;
            playerFrontline = PartyData.PlayerFrontline;
            playerBackline = PartyData.PlayerBackline;
            turntable = GameObject.Find("TimeTable").GetComponent<TurnTimeTable>();
            //Start Combat
            nextTurn();
        }

        static void nextTurn()
        {
            myTurn = turntable.advanceTurn();
            if (myTurn.GetType() == typeof(PlayerActor))
                turnState = TurnState.PlayerTurn;
            else
                turnState = TurnState.EnemyTurn;
            battleState = BattleState.BeforeTurn;
            //Debuffs
        }

        static bool StandardAttack(GenericActor target)
        {
            int finaldmg = 0;
            battleState = BattleState.DuringTurn;
            int basedmg = myTurn.StandardAttack(target);
            //TODO: Call function from monobehavior attached to UI to display damage
            //Actual dmg calculation
            battleState = BattleState.AfterTurn;
            dealDmg(target, finaldmg);
            return true;
        }

        private static void dealDmg(GenericActor target, int finaldmg)
        {
            throw new NotImplementedException();
        }

        static bool StandardAttack(GenericActor target, int type)
        {
            battleState = BattleState.DuringTurn;
            int basedmg = myTurn.StandardAttack(target);
            //TODO: Call function from monobehavior attached to UI to display damage
            //Writeline call to systemText noting damage, damage type, target, and attacker
            //Actual dmg calculation
            if (type == 0) ;
            if (type == 1) ;
            if (type == 2) ;
            battleState = BattleState.AfterTurn;
            return true;
        }
        static bool UseItem(Consumable item, GenericActor target)
        {
            battleState = BattleState.DuringTurn;
            item.Apply(target);
            //TODO: animation
            battleState = BattleState.AfterTurn;
            return true;
        }

        static bool Defend()
        {
            battleState = BattleState.DuringTurn;
            //TODO Apply Buff Defense to player that buffs defense, and temp 999 speed increase to move them to top of next Round
            battleState = BattleState.AfterTurn;
            return true;
        }

        static bool Skill(GenericSkill skill, List<GenericActor> targets)
        {
            battleState = BattleState.DuringTurn;
            //TODO:implement skill
            //TODO: Animation 
            //Writeline call to systemText noting skill name, damage/heal, type, target, and attacker
            battleState = BattleState.AfterTurn;
            return true;
        }

        static bool Flee()
        {
            battleState = BattleState.DuringTurn;
            //Logic and animations for determining successful Flee
            battleState = BattleState.AfterTurn;
            return false;
        }

        static bool EnemyFlee(EnemyActor enemy)
        {
            battleState = BattleState.DuringTurn;
            bool success = false;
            //Logic and animations for determining successful Flee
            if (success)
            {
                //remove enemy from EnemyData    
            }
            battleState = BattleState.AfterTurn;
            return false;
        }

        static bool MoveToPos(byte pos, int row)
        {
            GenericActor temp;
            int[] myPos = getPos();
            battleState = BattleState.DuringTurn;
            if(turnState == TurnState.PlayerTurn)
            {
                if(row == 1)
                {
                    if (playerFrontline[pos]) {
                        //animations stuff;
                        temp = playerFrontline[pos];
                        if (myPos[0] == 0)
                            playerFrontline[pos] = playerBackline[myPos[1]];
                        else
                            playerFrontline[pos] = playerFrontline[myPos[1]];
                        return true;
                    }
                    //Animations stuff
                    playerFrontline[pos] = (PlayerActor) myTurn;
                    if (myPos[0] == 0)
                        playerBackline[myPos[1]] = null;
                    else
                        playerFrontline[myPos[1]] = null;
                    return true;
                }
                else
                {
                    if (playerBackline[pos])
                    {
                        //animations stuff;
                        temp = playerBackline[pos];
                        if (myPos[0] == 0)
                            playerBackline[pos] = playerBackline[myPos[1]];
                        else
                            playerBackline[pos] = playerFrontline[myPos[1]];
                        return true;
                    }
                    //Animations stuff
                    playerBackline[pos] = (PlayerActor)myTurn;
                    if (myPos[0] == 0)
                        playerBackline[myPos[1]] = null;
                    else
                        playerFrontline[myPos[1]] = null;
                    return true;
                }
            }
            //enemy's turn
            else
            {
                if (row == 1)
                {
                    if (EnemyData.EnemyFrontline[pos])
                    {
                        //animations stuff;
                        temp = EnemyData.EnemyFrontline[pos];
                        if (myPos[0] == 0)
                            EnemyData.EnemyFrontline[pos] = EnemyData.EnemyBackline[myPos[1]];
                        else
                            EnemyData.EnemyFrontline[pos] = EnemyData.EnemyFrontline[myPos[1]];
                        return true;
                    }
                    //Animations stuff
                    EnemyData.EnemyFrontline[pos] = (EnemyActor)myTurn;
                    if (myPos[0] == 0)
                        EnemyData.EnemyBackline[myPos[1]] = null;
                    else
                        EnemyData.EnemyFrontline[myPos[1]] = null;
                    return true;
                }
                else
                {
                    if (EnemyData.EnemyBackline[pos])
                    {
                        //animations stuff;
                        temp = EnemyData.EnemyBackline[pos];
                        if (myPos[0] == 0)
                            EnemyData.EnemyBackline[pos] = EnemyData.EnemyBackline[myPos[1]];
                        else
                            EnemyData.EnemyBackline[pos] = EnemyData.EnemyFrontline[myPos[1]];
                        return true;
                    }
                    //Animations stuff
                    EnemyData.EnemyBackline[pos] = (EnemyActor)myTurn;
                    if (myPos[0] == 0)
                        EnemyData.EnemyBackline[myPos[1]] = null;
                    else
                        EnemyData.EnemyFrontline[myPos[1]] = null;
                    return true;
                }
            }
        }
        private static int[] getPos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Func: <c>CalculateDamage</c> (Static)
        /// <para>The default damage formula used for all attack action resolutions.</para>
        /// <para>
        ///     Current working damage formula: 
        ///     <code>damage = (caster.atk)^2 / (caster.atk + target.def)</code>
        /// </para>
        /// Params:
        /// <para>
        ///     <paramref name="atk"/>: the attacker's attack. 
        ///     <paramref name="def"/>: the target's defense.
        /// </para>
        /// </summary>
        public static int CalculateDamage(int atk, int def)
        {
            return (atk * atk) / (atk + def);
        }

        /// <summary>
        /// Func: <c>CalculateResistanceFactor</c> (Static)
        /// <para>The default resistance factor formula used for all attack action resolutions.</para>
        /// <para>
        ///     The resistance factor is derived from a dictionary mapping damage types
        ///     to floating point multipliers that range from 0 (immunity) to less than 1 (resistance)
        ///     to greater than 1 (weakness). If lexical retrieval fails then that means there is no
        ///     special multiplier for that resistance, i.e. neutrality. All Generic Actors possess
        ///     this dictionary.
        /// </para>
        /// Params:
        /// <para>
        ///     <paramref name="damageType"/>: the damage type. 
        ///     <paramref name="target"/>: the target.
        /// </para>
        /// </summary>
        public static float CalculateResistanceFactor(GenericSkill.DamageTypes damageType, GenericActor target)
        {
            //handle elemental resistances
            float resistanceFactor;
            try
            {
                resistanceFactor = target.WeakResist[damageType];
            }
            catch (KeyNotFoundException)
            {
                //not resistant, use multiplier 1x
                resistanceFactor = 1;
            }

            return resistanceFactor;
        }
    }
}
