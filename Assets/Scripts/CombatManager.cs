using System;

namespace BattleElements
{
    public static class CombatManager
    {   //Game State enum, to be used fir determining the game's state
        public enum BattleState { PlayerTurn, EnemyTurn, }
        public static BattleState state;

        static GenericActor[] battleParticipants;
        static GenericActor[] playerParty;
        static GenericActor[] enemyFormation;
        static TurnTimeTable turns;
        static GenericActor myTurn;

        //Static Constructor for the static combat manager will will be autmatically called at the the
        //first reference to it
        static CombatManager()
        {
            //Initializing All the fields
            playerParty = PartyData.PlayerParty;
            enemyFormation = EnemyData.Enemies;
            battleParticipants = new GenericActor[playerParty.Length + enemyFormation.Length];
            playerParty.CopyTo(battleParticipants, 0);
            enemyFormation.CopyTo(battleParticipants, playerParty.Length);
            turns = new TurnTimeTable(battleParticipants);
            myTurn = (GenericActor)turns.CurrentRound.Dequeue();
            //Done initializing
            if (myTurn.GetType() == typeof(PlayerActor))
                state = BattleState.PlayerTurn;
            else
                state = BattleState.EnemyTurn;
        }

    }
}
