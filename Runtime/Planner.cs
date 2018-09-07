using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    [CreateAssetMenu]
    public class Planner : ScriptableObject
    {
        public WorldState[] goals;
        public Action[] actionSet;

        public ActionPlan currentPlan;


        public static void FindActionsThatAchieve(WorldState goal, List<Action> availableActions, List<Action> results)
        {
            for (var i = 0; i < availableActions.Count; i++)
            {
                if (availableActions[i].effect.DoesSatisify(goal))
                    results.Add(availableActions[i]);
            }
        }

        public static void FindActionsThatCanRun(WorldState currentState, List<Action> availableActions, List<Action> results)
        {
            for (var i = 0; i < availableActions.Count; i++)
            {
                if (availableActions[i].precondition.DoesSatisify(currentState))
                    results.Add(availableActions[i]);
            }
        }

        public void SortActionListByCost(List<Action> actions)
        {
            actions.Sort((A, B) => A.cost.CompareTo(B.cost));
        }

        public void CreatePlan(WorldState currentState, int goalIndex)
        {
            currentPlan = new ActionPlan();
            currentPlan.goal = goals[goalIndex];
            // TODO
            // Given goal state, search backwards to find currentState, 
            // collecting actions into a list.
        }

        public void ExecutePlan(WorldState currentState)
        {
            var isComplete = currentPlan.Execute(currentState);
            if (isComplete)
            {
                // TODO
            }
        }
    }
}