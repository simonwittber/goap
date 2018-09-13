namespace GOAP
{
    [System.Serializable]
    public class Action
    {
        public float cost;
        public WorldState precondition;
        public WorldState effect;
        public System.Func<bool> proceduralPrecondition;
        public System.Func<bool> worker;

        public bool CanExecute(WorldState currentState)
        {
            if (currentState.DoesSatisify(precondition))
            {
                if (proceduralPrecondition != null)
                    return proceduralPrecondition.Invoke();
                else
                    return true;
            }
            return false;
        }

        public bool Execute() => worker.Invoke();

    }
}