using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elon
{
    internal class View
    {
        public static void Drive(Car car)
        {
            while (true)
            {
                if (car.GetBatteryCapacity() <= 0)
                {
                    Console.WriteLine("\nThe battery has run out! Would you like to recharge, or go back to main menu?");
                    Console.Write("\nrecharge | menu: ");
                    string Choice = Console.ReadLine()!;
                    switch (Choice)
                    {
                        case "recharge":
                            car.Recharge();
                            break;
                        case "menu":
                        default:
                            Controller.Menu();
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine($"Press any key to drive your {car.Color} car.\n");
                Console.WriteLine(string.Concat(Enumerable.Repeat("█", car.GetDrivenMeters() / 20)));
                Console.WriteLine($"\n{car.CarStatus()}");
                Console.ReadKey();
                car.Drive();
            }
        }
    }
}
