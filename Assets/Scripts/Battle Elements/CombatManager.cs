using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BattleElements
{

    public static class CombatManager
    {
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
  
        //Static Constructor for the static combat manager will will be autmatically called at the the
        //first reference to it
        static CombatManager()
        {
            //Initializing All the fields
            playerParty = PartyData.PlayerParty;
            enemyFormation = EnemyData.Enemies;
            playerFrontline = PartyData.playerFrontline;
            playerBackline = PartyData.playerBackline;
            battleParticipants = new GenericActor[playerParty.Length + enemyFormation.Length];
            playerParty.CopyTo(battleParticipants, 0);
            enemyFormation.CopyTo(battleParticipants, playerParty.Length);
            turns = new TurnTimeTable(battleParticipants);
            myTurn = (GenericActor)turns.CurrentRound.Dequeue();
            if (myTurn.GetType() == typeof(PlayerActor))
                turn = TurnState.PlayerTurn;
            else
                turn = TurnState.EnemyTurn;
            state = BattleState.Preturn;
        }

        static bool StandardAttack(GenericActor target)
        {
            state = BattleState.During;
            int basedmg = myTurn.StandardAttack();
            //TODO: Call function from monobehavior attached to UI to display damage
            //Actual dmg calculation
            state = BattleState.After;
            return true;
        }

        static bool UseItem(Consumable item)
        {
            state = BattleState.During;
            item.Apply(myTurn);
            //ToDO animation
            state = BattleState.After;
            return true;
        }

        static bool Defend()
        {
            return true;
        }

    }
}
