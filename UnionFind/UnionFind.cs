using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class UnionFind
    {
        private int[] parent;
        private int[] rank;

        // Constructor to initialize Union-Find data structure with `n` objects
        public UnionFind(int n)
        {
            parent = new int[n];
            rank = new int[n];

            for (int i = 0; i < n; i++)
            {
                parent[i] = i; // Each element is initially its own parent
                rank[i] = 0;   // The rank of each element is initially 0
            }
        }

        // Find the root of the element `x` with path compression
        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]); // Path compression
            }
            return parent[x];
        }

        // Union the sets containing elements `x` and `y`
        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                // Union by rank
                if (rank[rootX] > rank[rootY])
                {
                    parent[rootY] = rootX;
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                }
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }

        // Check if elements `x` and `y` are in the same set
        public bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}

