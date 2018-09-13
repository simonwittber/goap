using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GOAP
{
    [System.Serializable]
    public class WorldState
    {
        public enum State
        {
            EMPTY, TRUE, FALSE
        }

        [SerializeField] State[] values;

        public WorldState(int size)
        {
            values = new State[size];
        }

        public bool IsEmpty(int index) => values[index] == State.EMPTY;
        public bool IsTrue(int index) => values[index] == State.TRUE;
        public bool IsFalse(int index) => values[index] == State.FALSE;
        public void SetEmpty(int index) => values[index] = State.EMPTY;
        public void SetTrue(int index) => values[index] = State.TRUE;
        public void SetFalse(int index) => values[index] = State.FALSE;

        public void ApplyState(WorldState other)
        {
            for (var i = 0; i < values.Length; i++)
            {
                if (!other.IsEmpty(i))
                    values[i] = other.values[i];
            }
        }

        public bool DoesSatisify(WorldState other)
        {
            for (var i = 0; i < values.Length; i++)
            {
                //if the condition exists in other.
                if (!other.IsEmpty(i))
                {
                    //if I do not have that condition, early exit.
                    if (IsEmpty(i))
                        return false;
                    //If my value does not reach condition, early exit.
                    if (values[i] != other.values[i])
                        return false;
                }
            }
            return true;
        }
    }

}