using System;

namespace BattleElements
{
    public static class CombatManager
    {   //Game State enum, to be used fir determining the game's state
        public enum TurnState { PlayerTurn, EnemyTurn, }
        public static TurnState turn;
        public enum BattleState{ Preturn, During, After}
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
            if (myTurn.GetType() == typeof(PlayerActor))
                turn = TurnState.PlayerTurn;
            else
                turn = TurnState.EnemyTurn;
            state = BattleState.Preturn;
        }

        static bool StandardAttack(GenericActor target)
        {
            int dmg = myTurn.StandardAttack(target);
            return true;

        }

    }
}
