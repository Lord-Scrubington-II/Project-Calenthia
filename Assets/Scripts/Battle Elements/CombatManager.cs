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
        //Indicies for positions in front and backlines
        static readonly byte LEFT = 0;
        static readonly byte CENTER = 1;
        static readonly byte RIGHT = 2;
        //Game State enum, to be used fir determining the game's state
        public enum TurnState { PlayerTurn, EnemyTurn, }
        public static TurnState turn;
        public enum BattleState{ Preturn, During, After}
        public static BattleState state;


        static GenericActor[] battleParticipants;
        static GenericActor[] playerParty;
        static GenericActor[] enemyFormation;
        static PlayerActor[] playerFrontline;
        static PlayerActor[] playerBackline;
        static TurnTimeTable turns;
        static GenericActor myTurn;
  
        //Static Constructor for the static combat manager will be autmatically called at the the
        //first reference to it
        static CombatManager()
        {
            //Initializing All the fields
            playerParty = PartyData.PlayerParty;
            enemyFormation = EnemyData.Enemies;
            playerFrontline = PartyData.PlayerFrontline;
            playerBackline = PartyData.PlayerBackline;
            battleParticipants = new GenericActor[playerParty.Length + enemyFormation.Length];
            playerParty.CopyTo(battleParticipants, 0);
            enemyFormation.CopyTo(battleParticipants, playerParty.Length);
            turns = GameObject.Find("TimeTable").GetComponent<TurnTimeTable>();
            turns.initializeTurnOrder(battleParticipants);
            myTurn = (GenericActor)turns.CurrentRound.Dequeue();
            if (myTurn.GetType() == typeof(PlayerActor))
                turn = TurnState.PlayerTurn;
            else
                turn = TurnState.EnemyTurn;
            state = BattleState.Preturn;
        }


        static bool StandardAttack(GenericActor target)
        {
            int finaldmg = 0;
            state = BattleState.During;
            int basedmg = myTurn.StandardAttack();
            //TODO: Call function from monobehavior attached to UI to display damage
            //Actual dmg calculation
            state = BattleState.After;
            dealDmg(target, finaldmg);
            return true;
        }

        private static void dealDmg(GenericActor target, int finaldmg)
        {
            throw new NotImplementedException();
        }

        static bool StandardAttack(GenericActor target, int type)
        {
            state = BattleState.During;
            int basedmg = myTurn.StandardAttack();
            //TODO: Call function from monobehavior attached to UI to display damage
            //Actual dmg calculation
            if (type == 0) ;
            if (type == 1) ;
            if (type == 2) ;
            state = BattleState.After;
            return true;
        }
        static bool UseItem(Consumable item, GenericActor target)
        {
            state = BattleState.During;
            item.Apply(target);
            //ToDO: animation
            state = BattleState.After;
            return true;
        }

        static bool Defend()
        {
            state = BattleState.During;
            //TODO Apply Buff Defense to player that buffs defense, and temp 999 speed increase to move the, to top of next Round
            state = BattleState.After;
            return true;
        }

        static bool Skill(GenericSkill skill, List<GenericActor> targets)
        {
            state = BattleState.During;
            //TODO:implement skill
            //TODO: Animation 
            state = BattleState.After;
            return true;
        }

        static bool Flee()
        {
            state = BattleState.During;
            //Logic and animations for determining succesful Flee
            state = BattleState.After;
            return false;
        }

        static bool MoveToPos(byte pos, int row)
        {
            GenericActor temp;
            int[] myPos = getPos();
            state = BattleState.During;
            if(turn == TurnState.PlayerTurn)
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
    }
}
