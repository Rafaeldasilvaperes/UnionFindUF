
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace QuickUnionUFImproved
{
    public class WeightedQuickUnionUF
    {
        internal int[] _id { get; }
        private int[] _sz;
        public WeightedQuickUnionUF(int N) 
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

        //public void PrintUnions()
        //{            
        //    AnsiConsole.MarkupLine("\n[bold yellow]Your Current Connections[/]");            
                        
        //    var table = new Table();          
        //    table.AddColumn($"Index");           

        //    for (int i = 0; i < _id.Length; i++)
        //    {
        //        table.AddColumn($"{i}");
        //    }
        //    table.AddRow("Values", $"[bold blue][/]");
        //    for (int i = 0; i < _id.Length; i++)
        //    {
        //        table.UpdateCell(0,i+1, $"[bold blue]{_id[i]}[/]");                
        //    }

        //    AnsiConsole.Write(table);
        //    Console.WriteLine("\n");
        //}
    }
}
