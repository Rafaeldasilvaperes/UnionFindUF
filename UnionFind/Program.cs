using System.Threading.Channels;

namespace UnionFind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of elements:");
            var numeroInput = Console.ReadLine();
            int numeroInputInteger = Convert.ToInt32(numeroInput);
            UnionFind uf = new UnionFind(numeroInputInteger);

            while (true)
            {
                Console.WriteLine("Enter two numbers to union or type 'check' to check if connected (or type 'exit' to stop):");
                var input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (input.ToLower() == "check")
                {
                    Console.WriteLine("Type the two number you want to check if they are conected: ");
                    var checkInput = Console.ReadLine();
                    var checkInputs = checkInput.Split(' ');
                    while (checkInputs.Length != 2)
                    {
                        Console.WriteLine("Type only two numbers, please (or 'exit' to leave this option): ");
                        checkInput = Console.ReadLine();
                        if (checkInput.ToLower() == "exit")
                        {
                            break;
                        }
                        checkInputs = checkInput.Split(' ');
                    }
                    int c1 = Convert.ToInt32(checkInputs[0]);
                    int c2 = Convert.ToInt32(checkInputs[1]);
                    if (uf.Connected(c1, c2))
                    {
                        Console.WriteLine($"{c1} and {c2} are connected!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("They are not connected!");
                        continue;
                    }
                }

                var inputs = input.Split(' ');
                if (inputs.Length != 2)
                {
                    Console.WriteLine("Please enter exactly two numbers separated by a space.");
                    continue;
                }

                var x = Convert.ToInt32(inputs[0]);
                var y = Convert.ToInt32(inputs[1]);

                if (!uf.Connected(x, y))
                {
                    uf.Union(x, y);
                    Console.WriteLine($"Union({x}, {y})");
                }
                else
                {
                    Console.WriteLine($"{x} and {y} are already connected.");
                }
            }

        }
    }
}
