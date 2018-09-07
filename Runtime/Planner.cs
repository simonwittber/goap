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

        public void FindActionsThatAchieve(WorldState goal, List<Action> results)
        {
            for (var i = 0; i < actionSet.Length; i++)
            {
                if (actionSet[i].effect.DoesSatisfyGoal(goal))
                    results.Add(actionSet[i]);
            }
            results.Sort((A, B) => A.cost.CompareTo(B.cost));
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