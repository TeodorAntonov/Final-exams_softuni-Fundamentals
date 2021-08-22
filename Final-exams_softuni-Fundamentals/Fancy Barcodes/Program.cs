using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Fancy_Barcodes__Exam_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pathern = new Regex(@"(\@\#+)([A-Z][A-Za-z0-9]{4,})[A-Z](\@\#+)");

            StringBuilder sb = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();

                Match match = pathern.Match(cmd);

                if (match.Success)
                {
                    for (int j = 0; j < match.Length; j++)
                    {
                        if (char.IsDigit(cmd[j]))
                        {
                            sb.Append(cmd[j]);
                        }
                    }
                    if (sb.Length > 0)
                    {
                        Console.WriteLine($"Product group: {sb}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
                sb.Clear();
            }
        }
    }
}
