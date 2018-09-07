using System.Collections.Generic;

namespace GOAP
{
    [System.Serializable]
    public class WorldState
    {
        public Dictionary<int, int> states = new Dictionary<int, int>();

        /// <summary>
        /// Apply states from other to self.
        /// </summary>
        /// <param name="other"></param>
        public void ApplyEffect(WorldState other)
        {
            foreach (var k in other.states.Keys)
            {
                states[k] = other.states[k];
            }
        }

        /// <summary>
        /// Does this state satisfy requirements of other state?
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool DoesSatisify(WorldState other)
        {
            foreach (var k in other.states.Keys)
            {
                int value;
                if (states.TryGetValue(k, out value))
                {
                    if (states[k] < value)
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            return true;
        }

    }
}