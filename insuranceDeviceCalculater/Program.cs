namespace insuranceDeviceCalculater
{

    internal class Program
    {
        static decimal topDevicePrice = 0;
        static string topDeviceName = "";
        static decimal totalInsuranceCost = 0;

        static void Main(string[] args)
        {
            introScreen();
            char continueInput = 'y';
            while (continueInput != 0)

            {


                OneDeviceInsurance();//
                Console.WriteLine("Do you want to calculate another device? (y/n)");
                continueInput = Console.ReadKey().KeyChar;

            }
            outroScreen();
        }

        static void OneDeviceInsurance()
        {



            Console.WriteLine("\n Enter device name:");
            string name = Console.ReadLine();

            Console.WriteLine("\n Enter number of devices:");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Enter cost:");
            decimal cost = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("\n Enter category ( 1 laptop, 2 desktop, 3 other):");
            int category = Convert.ToInt32(Console.ReadLine());

            if (cost > topDevicePrice)
            {
                topDevicePrice = cost;
                topDeviceName = name;
            }

            decimal insuranceAmount;

            if (number > 5)
            {
                decimal firstFive = 5 * cost;
                decimal remaining = (number - 5) * cost * 0.9m;
                insuranceAmount = firstFive + remaining;
            }
            else
            {
                insuranceAmount = number * cost;
            }

            totalInsuranceCost += insuranceAmount;


            Console.WriteLine($"Total insurance cost: {totalInsuranceCost:C}");

        }
        static void introScreen()
        {
            Console.WriteLine(" _____ __   _ _______ _     _  ______ _______ __   _ _______ _______      _______ _______        _______ _     _        _______ _______  _____   ______\r\n   |   | \\  | |______ |     | |_____/ |_____| | \\  | |       |______      |       |_____| |      |       |     | |      |_____|    |    |     | |_____/\r\n __|__ |  \\_| ______| |_____| |    \\_ |     | |  \\_| |_____  |______      |_____  |     | |_____ |_____  |_____| |_____ |     |    |    |_____| |    \\_\r\n                                                                                                                                                       ");

        }
        static void outroScreen()
        {
            Console.WriteLine($"The most expensive device is {topDeviceName} with a price of {topDevicePrice:C}");
        }
    }
}
