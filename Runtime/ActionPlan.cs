namespace GOAP
{
    [System.Serializable]
    public struct ActionPlan
    {
        public WorldState goal;
        public Action[] actions;

        int index;

        public void Initialise()
        {
            index = 0;
        }

        public bool Execute(WorldState currentState)
        {
            var isComplete = actions[index].Execute(currentState);
            if (isComplete)
            {
                currentState.ApplyEffect(actions[index].effect);
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