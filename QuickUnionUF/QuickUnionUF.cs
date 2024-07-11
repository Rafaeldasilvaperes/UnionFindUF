using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickUnionUF
{
    public class QuickUnionUF
    {
        internal int[] _id { get; }

        public QuickUnionUF(int N)
        {
            _id = new int[N];
            for(int i = 0; i < N; i++)
            {
                _id[i] = i;
            }
        }

        private int Root(int i)
        {
            while (i != _id[i])
            {
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
            _id[x] = y;
        }
    }
}
