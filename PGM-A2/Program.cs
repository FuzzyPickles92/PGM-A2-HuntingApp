// DeMario Russell
// 04/16/2023
// CIS 215 - C# Programming(20143)
// PGM-A2
// Professor Peggy Peeples

using System;

namespace HuntingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            int numberOfDays, numberOfHunters = 0, numberOfHuntersn2 = 0;
            float huntCost = 0.00f, huntRate = 0.00f, totalHuntRate = 0.00f, totalHuntRaten2 = 0.00f, avgHuntRate = 0.00f, avgHuntRaten2 = 0.00f;
            string hunterName = "", hunterTypeName = "", huntCode = "", shift, hunterID, fieldCode, huntType;
            string answer;

            // Start of program
            Console.WriteLine("Do you have a hunter to enter? yes or no");
            answer = Console.ReadLine();

            // Asks for user input
            while (answer == "yes")
            {
                // Shift
                Console.WriteLine("Enter shift Code: Day or Night");
                shift = Console.ReadLine();

                // HunterID
                Console.WriteLine("Enter 100 or 200 for the HunterID");
                hunterID = Console.ReadLine();

                if (hunterID == "100")
                {
                    hunterName = "Bubba";
                }
                else if (hunterID == "200")
                {
                    hunterName = "Sammy";
                }
                else
                {
                    hunterName = "Unknown";
                }

                // FieldCode
                Console.WriteLine("Enter the field code, 41 or 51");
                fieldCode = Console.ReadLine();

                // HuntType
                Console.WriteLine("Enter the HuntType: 1, 2, 3, or 4");
                huntType = Console.ReadLine();

                if (huntType == "1")
                {
                    hunterTypeName = "Bow";
                }
                else if (huntType == "2")
                {
                    hunterTypeName = "Gun";
                }
                else if (huntType == "3")
                {
                    hunterTypeName = "Arrow";
                }
                else if (huntType == "4")
                {
                    hunterTypeName = "Sl-Shot";
                }
                else
                {
                    hunterTypeName = "Unknown";
                }

                // NumberOfDays
                Console.WriteLine("Enter the Number of days");
                if (!int.TryParse(Console.ReadLine(), out numberOfDays))
                {
                    numberOfDays = 0;
                }

                // Detailed Calculations for huntRate and huntCode
                if (fieldCode == "41")
                {
                    if (huntType == "1")
                    {
                        if (shift == "Day")
                        {
                            huntRate = 25.12f;
                            huntCode = "A-B-N";
                        }
                        else if (shift == "Night")
                        {
                            huntRate = 26.12f;
                            huntCode = "A-B-D";
                        }
                        else
                        {
                            huntRate = 126.12f;
                            huntCode = "A-B-O";
                        }
                    }
                    else if (huntType == "2")
                    {
                        if (shift == "Day")
                        {
                            huntRate = 13.22f;
                            huntCode = "A-G-D";
                        }
                        else if (shift == "Night")
                        {
                            huntRate = 14.22f;
                            huntCode = "A-G-N";
                        }
                        else
                        {
                            huntRate = 114.22f;
                            huntCode = "A-G-O";
                        }
                    }
                    else
                    {
                        huntRate = 125.12f;
                        huntCode = "A-O";
                    }
                }
                else if (fieldCode == "51")
                {
                    if (huntType == "3")
                    {
                        if (shift == "Day")
                        {
                            huntRate = 12.22f;
                            huntCode = "B-A-D";
                        }
                        else if (shift == "Night")
                        {
                            huntRate = 13.22f;
                            huntCode = "B-A-N";
                        }
                        else
                        {
                            huntRate = 113.22f;
                            huntCode = "B-A-O";
                        }
                    }
                    else if (huntType == "4")
                    {
                        if (shift == "Day")
                        {
                            huntRate = 5.55f;
                            huntCode = "B-S-D";
                        }
                        else if (shift == "Night")
                        {
                            huntRate = 6.55f;
                            huntCode = "B-S-N";
                        }
                        else
                        {
                            huntRate = 106.55f;
                            huntCode = "B-S-O";
                        }
                    }
                    else
                    {
                        huntRate = 200f;
                        huntCode = "B-O";
                    }
                }
                else
                {
                    huntRate = 0f;
                    huntCode = "Unknown";
                }

                // HuntCost
                huntCost = numberOfDays * huntRate;

                // Detailed output
                Console.WriteLine("Your hunter name is " + hunterName + ". ");
                Console.WriteLine("Your hunter code is " + huntCode + ". ");
                Console.WriteLine("Your hunter type name is " + hunterTypeName + ". ");
                Console.WriteLine("The number of days you are going to hunt is " + numberOfDays + ". ");
                Console.WriteLine("The cost is " + huntCost + ". ");

                // Summary calculations
                numberOfHunters = numberOfHunters + 1;
                totalHuntRate = totalHuntRate + huntRate;
                avgHuntRate = totalHuntRate / numberOfHunters;

                if (shift != "Day" && numberOfDays >= 2)
                {
                    numberOfHuntersn2 = numberOfHuntersn2 + 1;
                    totalHuntRaten2 = totalHuntRaten2 + huntRate;
                    avgHuntRaten2 = totalHuntRaten2 / numberOfHuntersn2;
                }

                // Asks if loop again
                Console.WriteLine("Do you have another to enter? YES or NO");
                answer = Console.ReadLine();
            }

            // Print of summary values
            Console.WriteLine("The number of hunters is " + numberOfHunters + ". ");
            Console.WriteLine("The total hunting rate for all hunters is " + totalHuntRate + ". ");
            Console.WriteLine("The average hunting rate for all hunters is " + avgHuntRate + ". ");
            Console.WriteLine("The number of hunters with shift not equal to 'Day' and number of days >= 2 is " + numberOfHuntersn2 + ". ");
            Console.WriteLine("The total hunting rate for these hunters is " + totalHuntRaten2 + ". ");
            Console.WriteLine("The average hunting rate for these hunters is " + avgHuntRaten2 + ". ");
        }
    }
}

