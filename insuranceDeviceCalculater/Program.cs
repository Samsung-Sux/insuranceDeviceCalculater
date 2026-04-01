using System;

namespace insuranceDeviceCalculater
{
    internal class Program
    {// could add all the global variables but for simplicity, keeping them in the main class
        static decimal topDevicePrice = 0;
        static string topDeviceName = "";
        static decimal totalInsuranceCost = 0;
        static decimal DEPRECIATION_RATE = 0.05m;
        static int laptopCount = 0;
        static int desktopCount = 0;
        static int otherCount = 0;
        static void Main(string[] args)
        {
            introScreen();

            char continueInput = 'y';

            while (continueInput == 'y' || continueInput == 'Y')
            {
                OneDeviceInsurance();

                Console.WriteLine("\nDo you want to calculate another device? (y/n)");
                continueInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

            outroScreen();
        }

        static void OneDeviceInsurance()
        {
            string name;
            while (true)
            {
                Console.WriteLine("\nEnter device name:");
                name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                    break;

                Console.WriteLine("Invalid input. Device name cannot be empty.");
            }

            int number;
            Console.WriteLine("\nEnter number of devices:");
            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.WriteLine("Enter a valid positive number:");
            }

            decimal cost;
            Console.WriteLine("\nEnter cost per device:");
            while (!decimal.TryParse(Console.ReadLine(), out cost) || cost <= 0)
            {
                Console.WriteLine("Enter a valid cost:");
            }

            int category;
            Console.WriteLine("\nEnter category (1 = laptop, 2 = desktop, 3 = other):");

            while (!int.TryParse(Console.ReadLine(), out category) || category < 1 || category > 3)
            {
                Console.WriteLine("Enter 1, 2, or 3:");
            }

       
            if (category == 1)
                laptopCount += number;
            else if (category == 2)
                desktopCount += number;
            else
                otherCount += number;
            decimal value = cost;
            string depreciationTable = "\nMonth\tValue";

            for (int i = 1; i <= 6; i++)
            {
                value -= value * DEPRECIATION_RATE;
                value = Math.Round(value, 2);

                depreciationTable += $"\n{i}\t{value:C}";
            }

            decimal depreciatedCost = value;

            // Track most expensive device
            if (cost > topDevicePrice)
            {
                topDevicePrice = cost;
                topDeviceName = name;
            }

            decimal insuranceAmount;

            if (number > 5)
            {
                decimal firstFive = 5 * depreciatedCost;
                decimal remaining = (number - 5) * depreciatedCost * 0.9m;
                insuranceAmount = firstFive + remaining;
            }
            else
            {
                insuranceAmount = number * depreciatedCost;
            }

            totalInsuranceCost += insuranceAmount;

            Console.WriteLine(depreciationTable);
            Console.WriteLine($"\nDepreciated value per device: {depreciatedCost:C}");
            Console.WriteLine($"Insurance for this entry: {insuranceAmount:C}");
            Console.WriteLine($"Running total insurance: {totalInsuranceCost:C}");
        }

        

       
       static void introScreen()
        {
            Console.WriteLine(" _____ __   _ _______ _     _  ______ _______ __   _ _______ _______      _______ _______        _______ _     _        _______ _______  _____   ______\r\n   |   | \\  | |______ |     | |_____/ |_____| | \\  | |       |______      |       |_____| |      |       |     | |      |_____|    |    |     | |_____/\r\n __|__ |  \\_| ______| |_____| |    \\_ |     | |  \\_| |_____  |______      |_____  |     | |_____ |_____  |_____| |_____ |     |    |    |_____| |    \\_\r\n                                                                                                                                                       ");
        }

        static void outroScreen()
        {
            Console.WriteLine($"\nMost expensive device: {topDeviceName} ({topDevicePrice:C})");
            Console.WriteLine($"Total insurance cost: {totalInsuranceCost:C}");
            Console.WriteLine($"The number of laptops: {laptopCount}");
            Console.WriteLine($"The number of desktops: {desktopCount}");
            Console.WriteLine($"The number of other devices: {otherCount}");
        }
    }
}
