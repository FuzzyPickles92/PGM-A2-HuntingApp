// DeMario Russell
// 03/29/2023
// CIS 215 - C# Programming(20143)
// PGM-A2
// Professor Peggy Peeples

using System;
using System.Collections.Generic;
using System.Linq;

namespace HuntingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define dictionaries for hunter names, hunter types, and hunting rates.
            Dictionary<int, string> HunterNames = new Dictionary<int, string>
            {
                { 100, "Hunter 1" },
                { 200, "Hunter 2" }
            };

            Dictionary<int, string> HunterTypeNames = new Dictionary<int, string>
            {
                { 1, "Bow" },
                { 2, "Gun" },
                { 3, "Arrow" },
                { 4, "SL-Shot" }
            };

            Dictionary<int, double> HuntingRates = new Dictionary<int, double>
            {
                { 41, 50.0 },
                { 51, 75.0 }
            };

            Console.WriteLine("Welcome to the Hunting App!");

            // Variables for loop control and summary calculations.
            bool processAnotherHunter = true;
            List<double> huntCosts = new List<double>();
            List<double> dayGunHuntCosts = new List<double>();
            List<double> otherHuntRates = new List<double>();

            // Main loop for processing hunters.
            while (processAnotherHunter)
            {
                // Declare variables for user input.
                int shift, hunterId, fieldCode, huntType, numOfDays;
                string hunterName, hunterTypeName;
                double huntingRate, huntCost;

                Console.WriteLine("Please enter the following details:");

                // Get user input for shift code, hunter ID, field code, hunt type, and number of days to hunt.
                do
                {
                    Console.Write("Shift code (1: Day, 2: Night): ");
                    int.TryParse(Console.ReadLine(), out shift);
                } while (shift != 1 && shift != 2);

                do
                {
                    Console.Write("Hunter ID (100 or 200): ");
                    int.TryParse(Console.ReadLine(), out hunterId);
                } while (hunterId != 100 && hunterId != 200);

                do
                {
                    Console.Write("Field code (41 or 51): ");
                    int.TryParse(Console.ReadLine(), out fieldCode);
                } while (fieldCode != 41 && fieldCode != 51);

                do
                {
                    Console.Write("Hunt type (1: Bow, 2: Gun, 3: Arrow, 4: SL-Shot): ");
                    int.TryParse(Console.ReadLine(), out huntType);
                } while (huntType < 1 || huntType > 4);

                do
                {
                    Console.Write("Number of days to hunt (1-5): ");
                    int.TryParse(Console.ReadLine(), out numOfDays);
                } while (numOfDays < 1 || numOfDays > 5);

                // Retrieve hunter and hunt type information, calculate hunting costs.
                hunterName = HunterNames[hunterId];
                hunterTypeName = HunterTypeNames[huntType];
                huntingRate = HuntingRates[fieldCode];
                huntCost = huntingRate * numOfDays;

                // Display hunt details and cost for the current hunter.
                Console.WriteLine($"\nHunter {hunterName} (ID: {hunterId}) hunted using {hunterTypeName} for {numOfDays} day(s).");
                Console.WriteLine($"Total hunt cost: ${huntCost:0.00}");

                // Update summary lists
                huntCosts.Add(huntCost);
                if (shift == 1 && huntType == 2)
                {
                    dayGunHuntCosts.Add(huntCost);
                }
                if (shift != 1 && numOfDays >= 2)
                {
                    otherHuntRates.Add(huntingRate);
                }

                Console.Write("\nDo you want to process another hunter? (y/n): ");
                processAnotherHunter = Console.ReadLine().ToLower() == "y";
            }

            Console.WriteLine("\nSummary:");
            Console.WriteLine($"Total hunters processed: {huntCosts.Count}");
            Console.WriteLine($"Total hunt cost: ${huntCosts.Sum():0.00}");

            string avgDayGunHunts = dayGunHuntCosts.Count > 0 ? $"{dayGunHuntCosts.Average():0.00}" : "N/A";
            Console.WriteLine($"Average cost of day gun hunts: ${avgDayGunHunts}");

            string highestHuntingRate = otherHuntRates.Count > 0 ? $"{otherHuntRates.Max():0.00}" : "N/A";
            Console.WriteLine($"Highest hunting rate (excluding day 1 hunts with 2+ days): ${highestHuntingRate}");


            //Thank you message.
            Console.WriteLine("\nThank you for using the Hunting App!");
        }
    }
}
//End of program.