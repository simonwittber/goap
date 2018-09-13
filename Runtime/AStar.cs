using System;
using System.Collections.Generic;
using System.Linq;

namespace GOAP
{
    public class AStar<T> where T : class
    {
        Dictionary<T, float> g;
        Dictionary<T, T> parent;
        Dictionary<T, bool> inPath;
        Queue<T> path;
        HashList<T> openset;
        HashSet<T> closedset;

        public System.Func<T, IEnumerable<T>> GetConnectedNodes;
        public System.Func<T, T, float> CalculateMoveCost;

        public AStar()
        {
            g = new Dictionary<T, float>();
            parent = new Dictionary<T, T>();
            inPath = new Dictionary<T, bool>();
            openset = new HashList<T>();
            closedset = new HashSet<T>();
            path = new Queue<T>();
        }

        public bool Route(T start, T end, List<T> nodes, List<T> route)
        {
            route.Clear();
            if (start == null || end == null)
            {
                return false;
            }

            for (int i = 0, nodesLength = nodes.Count; i < nodesLength; i++)
            {
                var s = nodes[i];
                g[s] = 0f;
                parent[s] = null;
                inPath[s] = false;
            }
            openset.Clear();
            closedset.Clear();
            path.Clear();

            var current = start;
            openset.Add(current);
            while (openset.Count > 0)
            {
                current = openset[0];
                for (var i = 1; i < openset.Count; i++)
                {
                    var d = g[current].CompareTo(g[openset[i]]);
                    if (d < 0)
                    {
                        current = openset[i];
                    }
                }
                //openset.Sort ((a,b) => g [a].CompareTo (g [b]));
                current = openset[0];
                if (current == end)
                {
                    while (parent[current] != null)
                    {
                        path.Enqueue(current);
                        inPath[current] = true;
                        current = parent[current];
                        if (path.Count >= nodes.Count)
                        {
                            return false;
                        }
                    }
                    inPath[current] = true;
                    path.Enqueue(current);
                    while (path.Count > 0)
                    {
                        route.Add(path.Dequeue());
                    }
                    return true;
                }
                openset.Remove(current);
                closedset.Add(current);
                var connectedNodes = GetConnectedNodes(current);
                foreach (var node in connectedNodes)
                {
                    if (closedset.Contains(node))
                        continue;
                    if (openset.Contains(node))
                    {
                        var new_g = g[current] + CalculateMoveCost(current, node);
                        if (g[node] > new_g)
                        {
                            g[node] = new_g;
                            parent[node] = current;
                        }
                    }
                    else
                    {
                        g[node] = g[current] + CalculateMoveCost(current, node);
                        parent[node] = current;
                        openset.Add(node);
                    }
                }
            }
            return false;
        }
    }
}