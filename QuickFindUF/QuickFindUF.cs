using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFindUF
{
    public class QuickFindUF
    {
        internal int[] _id { get; }

        public QuickFindUF(int N)
        {
            _id = new int[N + 1];
            for(int i = 0; i < N; i++)
            {
                _id[i] = i;
            }
        }

        public bool IsConnected(int p, int q)
        {
            return _id[p] == _id[q];
        }

        public void Union(int p, int q)
        {
            int pRoot = _id[p];
            int qRoot = _id[q];
            for(int i = 0;i < _id.Length; i++) 
            {
                if (_id[i] == pRoot)
                {
                    _id[i] = qRoot;
                }
            }
        }
    }
}
