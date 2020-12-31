using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleElements
{ 
    public class TurnTimeTable: MonoBehaviour
    {
        private SortedSet<GenericActor> queueOne;
        private SortedSet<GenericActor> queueTwo;

        private SortedSet<GenericActor> currentRound;
        private SortedSet<GenericActor> nextRound;

        public SortedSet<GenericActor> CurrentRound { get => currentRound; set => currentRound = value; }
        public SortedSet<GenericActor> NextRound { get => nextRound; set => nextRound = value; }

        public GenericActor advanceTurn()
        {
            GenericActor turn = currentRound.Max;
            currentRound.Remove(turn);
            if(currentRound.Count == 0)
            {
                currentRound = queueTwo;
            }
            return turn;
        }

        private void updateNextRound()
        {

        }

        public void SpeedChange(GenericActor target)
        {

        }

        private void Start()
        {

        }

        private void Awake()
        {
            this.name = "TimeTable";
            queueOne = new SortedSet<GenericActor>(((GenericActor[])CombatManager.playerParty).Concat(CombatManager.enemyFormation), new SpeedComp());
            currentRound = queueOne;
            updateNextRound();
        }
    }
}