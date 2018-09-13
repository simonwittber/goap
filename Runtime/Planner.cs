using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GOAP
{
    [CreateAssetMenu]
    public class Planner : ScriptableObject
    {
        public WorldState[] goals;
        public List<Action> actionSet;

        public ActionPlan currentPlan;
        public AStar<Action> actionGraph;

        void OnEnable()
        {
            actionGraph = new AStar<Action>();
            actionGraph.GetConnectedNodes = GetConnectedNodes;
            actionGraph.CalculateMoveCost = CalculateMoveCost;
        }

        float CalculateMoveCost(Action src, Action dst)
        {
            return dst.cost;
        }

        IEnumerable<Action> GetConnectedNodes(Action goal)
        {
            foreach (var action in actionSet)
            {
                if (action.effect.DoesSatisify(goal.precondition))
                    yield return action;
            }
        }

        public void CreatePlan(WorldState currentState, int goalIndex)
        {
            //given a current state, there are many actions that may have the precondition for that state.
            var plans = new List<ActionPlan>();
            var route = new List<Action>();
            foreach (var endAction in NodesThatCanCreateState(goals[goalIndex]))
            {
                //given a goal, there are many actions that may create that state.
                foreach (var startAction in NodesThatCanExecuteWithState(currentState))
                {
                    if (actionGraph.Route(endAction, startAction, actionSet, route))
                    {
                        var plan = new ActionPlan(goals[goalIndex], currentState, route);
                        plans.Add(plan);
                    }
                }
            }
            if (plans.Count > 0)
            {
                plans.Sort((A, B) => A.cost.CompareTo(B.cost));
                currentPlan = plans[0];
            }
        }

        IEnumerable<Action> NodesThatCanExecuteWithState(WorldState state)
        {
            foreach (var action in actionSet)
            {
                if (state.DoesSatisify(action.precondition))
                    yield return action;
            }
        }

        IEnumerable<Action> NodesThatCanCreateState(WorldState state)
        {
            foreach (var action in actionSet)
            {
                if (action.effect.DoesSatisify(state))
                    yield return action;
            }
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