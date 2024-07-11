
using Spectre.Console;
using System.Security.Cryptography;

namespace Shared
{
    public static class Utils
    {
        public static bool IsBetween(int x, int a, int N)
        {
            return (x >= 0 && x <= N) && (a >= 0 && a <= N);
        }

        public static void PrintUnions(int[] dataArray)
        {
            AnsiConsole.MarkupLine("\n[bold yellow]Your Current Connections[/]");

            var table = new Table();

            table.AddColumn($"[bold]Index[/]");

            for (int i = 0; i < dataArray.Length; i++)
            {
                table.AddColumn($"[blue]{i}[/]");
            }

            table.AddRow("[bold]Values[/]");

            for (int i = 0; i < dataArray.Length; i++)
            {
                table.UpdateCell(0, i + 1, $"[green]{dataArray[i]}[/]");
            }

            AnsiConsole.Write(table);
            Console.WriteLine("\n");
        }

        public static void PrintWithColor(string message, string color)
        {
            AnsiConsole.MarkupLine($"\n[bold {color}]{message}[/]");
        }
    }
}
