using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04___QuickUnionWithPathCompression
{
    public class WeightedQuickUnionWithPathCompressionUF
    {
        internal int[] _id { get; }
        private int[] _sz;
        public WeightedQuickUnionWithPathCompressionUF(int N)
        {
            _id = new int[N];
            _sz = new int[N];
            for (int i = 0; i < N; i++)
            {
                _id[i] = i;
                _sz[i] = 1;
            }
        }

        private int Root(int i)
        {
            while (i != _id[i])
            {
                _id[i] = _id[_id[i]]; // path compreesion!
                i = _id[i];
            }
            return i;
        }

        public bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            int x = Root(p);
            int y = Root(q);

            if (x == y)
                return;

            if (_sz[x] < _sz[y])
            {
                _id[x] = y;
                _sz[y] += _sz[x];
            }
            else
            {
                _id[y] = x;
                _sz[x] += _sz[y];
            }
        }
    }
}
