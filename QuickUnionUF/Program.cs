using Shared;

namespace QuickUnionUF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstInput;

            do
            {
                Utils.PrintWithColor($"-> Enter the size our sample will be: ", "yellow");

                firstInput = Console.ReadLine();

            } while (string.IsNullOrEmpty(firstInput));
            
            int N = Convert.ToInt32(firstInput);

            var qu = new QuickUnionUF(N);

            var randomNumbers = new Random();
            var rn = () => randomNumbers.Next(N + 1);

            // Random Unions based on one halve of N
            for (int i = 0; i < (N / 2); i++)
            {
                qu.Union(rn(), rn());
            }           

            while (true)
            {
                string input;

                do
                {
                    Utils.PrintWithColor($"-> Enter two numbers separated by space between 0 and {N}: ", "yellow");
                    Utils.PrintWithColor($"(Type \"Connections\" to see your connections) ", "yellow");

                    input = Console.ReadLine();

                } while (string.IsNullOrEmpty(input));

                if (input.Trim().ToUpper().Equals("CONNECTIONS"))
                {
                    Utils.PrintUnions(qu._id);
                    continue;
                }

                var inputArray = input.Split(' ');

                if (inputArray.Length != 2 || string.IsNullOrEmpty(inputArray[0]) || string.IsNullOrEmpty(inputArray[1]))
                {
                    Utils.PrintWithColor($">>>> Gotta be two numbers between 0 and {N} separated by space!", "red");
                    continue;
                }


                bool xConverted = int.TryParse(inputArray[0], out int x);
                bool yConverted = int.TryParse(inputArray[1], out int y);

                if (!xConverted || !yConverted)
                {
                    Utils.PrintWithColor($">>>> Only numbers, please!", "red");
                    continue;
                }

                if (Utils.IsBetween(x, y, N))
                {
                    if (qu.IsConnected(x, y))
                    {
                        Utils.PrintWithColor($"{x} and {y} are connected!", "green");
                    }
                    else
                    {
                        Utils.PrintWithColor($"{x} and {y} are NOT connected.", "blue");
                    }
                }
                else
                {
                    Utils.PrintWithColor($">>>> One or more values out of the reach from sample size!", "red");
                }
            }
        }
    }
}
