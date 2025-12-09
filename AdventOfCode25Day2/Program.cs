using System.Numerics;

namespace AdventOfCode25Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader readingFile = new StreamReader("U:/AOC25D2.txt");
            string AllIDs = readingFile.ReadToEnd();
            int DashPos = 0;
            int CommaPos = 0;
            BigInteger Num1 = 0;
            BigInteger Num2 = 0;
            bool StringEnd = false;
            string NumAsString = "";
            int NumLength = 0;
            BigInteger SumInvalidIDs = 0;
            while (StringEnd == false)
            {

                // Getting the values out of the string
                DashPos = AllIDs.IndexOf("-");
                CommaPos = AllIDs.IndexOf(",");
                // Console.WriteLine($"{DashPos}, {CommaPos}");
                Num1 = BigInteger.Parse(AllIDs.Substring(0, DashPos));
                if (CommaPos == -1)
                {
                    StringEnd = true;
                    Num2 = BigInteger.Parse(AllIDs.Substring(DashPos + 1));
                }
                else
                {
                    Num2 = BigInteger.Parse(AllIDs.Substring(DashPos + 1, CommaPos - (DashPos + 1)));
                    AllIDs = AllIDs.Substring(CommaPos + 1);
                }
                // Console.WriteLine($"Num1 is {Num1}, Num2 is {Num2}");

                // finding the IDs
                for (BigInteger i = Num1; i <= Num2; i++)
                {
                    NumAsString = Convert.ToString(i);
                    NumLength = NumAsString.Length;
                    if (NumLength % 2 == 0)
                    {
                        // 4545 
                        if (NumAsString.Substring(0, NumLength / 2) == NumAsString.Substring(NumLength / 2))
                        {
                            Console.WriteLine($"Invalid for {i}");
                            SumInvalidIDs += i;
                        }
                    }
                }
            }
            Console.WriteLine(SumInvalidIDs);
        }
    }
}
