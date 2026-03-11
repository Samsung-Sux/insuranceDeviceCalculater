namespace insuranceDeviceCalculater
{

    internal class Program
    {
        static decimal topDevicePrice = 0;
        static string topDeviceName = "";
        static decimal totalInsuranceCost = 0;
        static void Main(string[] args)
        {

            OneDeviceInsurance();
        }

            static void OneDeviceInsurance()
            {
                Console.WriteLine("Insurance Calculator");

                for (int i = 0; i < 4; i++)   // sample table has 4 devices
                {
                    Console.WriteLine("Enter device name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter number of devices:");
                    int number = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter cost:");
                    decimal cost = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Enter category (1 laptop, 2 desktop, 3 other):");
                    int category = Convert.ToInt32(Console.ReadLine());

                    // track most expensive device
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
                }

                Console.WriteLine($"Total insurance cost: {totalInsuranceCost:C}");
                Console.WriteLine($"Most expensive device: {topDeviceName} at {topDevicePrice:C}");
            }
        }
    }
