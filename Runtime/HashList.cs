using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GOAP
{
    /// <summary>
    /// A HashList is like a normal List, but with a O(1) Contains method, which comes at the expense of using 2x memory.
    /// </summary>
    public class HashList<T> : List<T>
    {
        HashSet<T> itemSet = new HashSet<T>();

        public new void Add(T item)
        {
            base.Add(item);
            itemSet.Add(item);
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            itemSet.Remove(item);
        }

        public new bool Contains(T item)
        {
            return itemSet.Contains(item);
        }

        public new void Clear()
        {
            base.Clear();
            itemSet.Clear();
        }
    }
}


