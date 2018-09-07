using System.Collections.Generic;

namespace GOAP
{
    [System.Serializable]
    public struct WorldState
    {

        public bool DoesSatisfyCondition(WorldState condition)
        {
            //TODO
            return true;
        }

        public bool DoesSatisfyGoal(WorldState goal)
        {
            //TODO
            return true;
        }

        public WorldState ApplyEffect(WorldState effect)
        {
            //TODO
            return effect;
        }

    }
}