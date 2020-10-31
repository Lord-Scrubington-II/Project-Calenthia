using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleElements
{ 
    public class TurnTimeTable
    {
        private System.Collections.Queue queueOne;
        private System.Collections.Queue queueTwo;

        private System.Collections.Queue currentRound;
        private System.Collections.Queue nextRound;

        public Queue CurrentRound { get => currentRound; set => currentRound = value; }
        public Queue NextRound { get => nextRound; set => nextRound = value; }

        
        public TurnTimeTable(GenericActor[] actors)
        {

        }

        private System.Collections.Queue initializeTurnOrder()
        {
            return null;
        }

        public GenericActor advanceTurn()
        {
            return null;
        }

        private void updateNextRound()
        {

        }
    }
}