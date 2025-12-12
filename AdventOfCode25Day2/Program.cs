using System.Numerics;

namespace AdventOfCode25Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part2();
            //List<int[]> FactorPairs = new List<int[]>();
            //FactorPairs.Add(new int[] { 1, 2, 3 });
            //Console.WriteLine(FactorPairs[0][2]);
            //Console.WriteLine(Math.Sqrt(3));
            //Console.WriteLine(Math.Floor(Math.Sqrt(3)));
            //Console.WriteLine(Math.Floor(5.6));
            //for (int i = 1; i < 6; i+=2)
            //{
            //    Console.WriteLine(i);
            //}
        }
        static void Part1()
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

        static void Part2()
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
            List<int[]> FactorPairs = new List<int[]>();
            int Limit = 0;
            bool Invalid = false;
            int test = 0;
            while (StringEnd == false && test < 1)
            {
                test++;
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
                    Limit = Convert.ToInt32(Math.Floor(Math.Sqrt(NumLength)));
                    FactorPairs.Clear();
                    for (int j = 1; j <= Limit; j++)
                    {
                        if (NumLength % j == 0)
                        {
                            FactorPairs.Add(new int[] { j, NumLength / j });
                        }
                    }
                    // 45 45 45 45
                    Invalid = true;
                    for (int j = 0; j < FactorPairs.Count; j++)
                    {
                        for (int n = FactorPairs[j][0]; n < NumLength; n += FactorPairs[j][0])
                        {
                            if (NumAsString.Substring(0, FactorPairs[j][0]) != NumAsString.Substring(n, FactorPairs[j][0]))
                            {
                                //        Console.WriteLine($"Invalid for {i}");
                                Console.WriteLine($"We have found {i} to be invalid because {NumAsString.Substring(0, FactorPairs[j][0])} does not equal {NumAsString.Substring(n, FactorPairs[j][0])} ");
                                Invalid = false;
                                // Even if it is invalid for one combination it makes it valid if not all combinations work
                            }
                        } // Checking 2nd factor iterations of 1st factor
                        for (int n = FactorPairs[j][1]; n < NumLength; n += FactorPairs[j][1])
                        {
                            if (NumAsString.Substring(0, FactorPairs[j][1]) != NumAsString.Substring(n, FactorPairs[j][1]))
                            {
                                
                                Invalid = false;
                            }
                        }
                    }
                    
                    if (Invalid == true)
                    {
                        Console.WriteLine(NumLength);
                        for (int j = 0; j < FactorPairs.Count; j++)
                        {
                            Console.WriteLine(FactorPairs[j][0]);
                            Console.WriteLine(FactorPairs[j][1]);
                        }
                            Console.WriteLine($"The range is {Num1} to {Num2}");
                        Console.WriteLine($"Invalid for {i}");
                        SumInvalidIDs += i;
                    }
                    //if (NumLength % 2 == 0)
                    //{
                    //    // 4545 
                    //    if (NumAsString.Substring(0, NumLength / 2) == NumAsString.Substring(NumLength / 2))
                    //    {
                    //        Console.WriteLine($"Invalid for {i}");
                    //        SumInvalidIDs += i;
                    //    }
                    //}
                }
            }
            Console.WriteLine(SumInvalidIDs);
        }
    }
}
