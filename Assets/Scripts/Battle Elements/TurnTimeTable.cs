using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleElements
{ 
    public class TurnTimeTable: MonoBehaviour
    {
        private System.Collections.Queue queueOne;
        private System.Collections.Queue queueTwo;

        private System.Collections.Queue currentRound;
        private System.Collections.Queue nextRound;

        public Queue CurrentRound { get => currentRound; set => currentRound = value; }
        public Queue NextRound { get => nextRound; set => nextRound = value; }

        public void initializeTurnOrder(GenericActor[] actors)
        {
            
        }

        public GenericActor advanceTurn()
        {
            return null;
        }

        private void updateNextRound()
        {

        }
        private void Start()

        {
            this.name = "TimeTable";
        }
    }
}