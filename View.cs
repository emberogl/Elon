using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elon
{
    internal class View
    {
        /// <summary>
        /// A main menu that checks if there are any cars saved to file, if not,
        /// immediately prompts to create a new car.
        /// 
        /// If there are any cars saved to file, they are loaded to the list in CarHandler
        /// for the user to interact with.
        /// </summary>
        public static void Menu()
        {
            Model.ImportCars(); // Retrieving car list from disk
            Console.Clear();
            if (Model.Cars!.Count == 0)
            {
                Console.WriteLine("No cars to display; press any key to create one.");
                Console.ReadKey();
                Controller.AddCar();
            }
            else
            {
                int CarCount = 1;
                foreach (Car car in Model.Cars)
                {
                    Console.WriteLine($"({CarCount}) A {car.Color} car has been found.");
                    CarCount++;
                }
                Console.WriteLine("\nDrive a car");
                Console.WriteLine("Delete a car");
                Console.WriteLine("Add a car");
                Console.Write("\ndrive | delete | add: ");
                string Choice = Console.ReadLine()!;
                switch (Choice)
                {
                    case "drive":
                        Controller.DriveSelection();
                        break;
                    case "delete":
                        Controller.DeleteCar();
                        break;
                    case "add":
                        Controller.AddCar();
                        break;
                    default:
                        Menu();
                        break;
                }
            }
        }

        // Driving loop until car runs out of charge.
        public static void Drive(Car car)
        {
            while (true)
            {
                if (car.GetBatteryCapacity() <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("The battery has run out! Would you like to recharge, or go back to main menu?");
                    Console.Write("\nrecharge | menu: ");
                    string Choice = Console.ReadLine()!;
                    switch (Choice)
                    {
                        case "recharge":
                            car.Recharge();
                            break;
                        default:
                            Menu();
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine($"Press any key to drive your {car.Color} car.\n");
                Console.WriteLine(string.Concat(Enumerable.Repeat("█", (int)car.GetDrivenMeters() / Car.MetersPerBatteryUsage))); // Driven distance visualizer
                Console.WriteLine($"\n{car.CarStatus()}");
                Model.ExportCars(); // Reflecting kilometerage gain to disk file.
                Console.ReadKey();
                car.Drive();
            }
        }

        public static void InvalidMessage()
        {
            Console.Clear(); Console.WriteLine("Invalid."); Console.ReadKey(); Menu();
        }
    }
}