using DifferentMethods.Univents;

namespace GOAP
{
    [System.Serializable]
    public struct Action
    {
        public float cost;
        public WorldState precondition;
        public WorldState effect;
        public PredicateList proceduralPrecondition;

        public bool CanExecute(WorldState currentState)
        {
            if (currentState.DoesSatisfyCondition(precondition))
            {
                proceduralPrecondition.Invoke();
                return proceduralPrecondition.Result;
            }
            return false;
        }

        public bool Execute(WorldState currentState)
        {
            return true;
        }
    }
}