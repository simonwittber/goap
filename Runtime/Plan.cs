using System.Collections.Generic;
using System.Linq;

namespace GOAP
{
    [System.Serializable]
    public class Plan
    {
        public readonly WorldState goal;
        public readonly WorldState initialState;
        public readonly Action[] actions;
        public readonly float cost;

        int index;

        public void Initialise()
        {
            index = 0;
        }

        public Plan(WorldState goal, WorldState initialState, IList<Action> actions)
        {
            this.goal = goal;
            this.initialState = initialState;
            this.actions = actions.ToArray();
            cost = 0;
            foreach (var i in actions)
            {
                cost += i.cost;
            }
        }

        public bool Execute(WorldState currentState)
        {
            var isComplete = actions[index].Execute();
            if (isComplete)
            {
                currentState.ApplyState(actions[index].effect);
                index += 1;
                if (index >= actions.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}