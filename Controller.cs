using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elon
{
    internal class Controller
    {
        public static void Start() 
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
            if (CarHandler.Cars!.Count == 0)
            {
                Console.WriteLine("No cars have been found.");
                AddCar();
            }
            else
            {
                int CarCount = 1;
                foreach (Car car in CarHandler.Cars)
                {
                    Console.WriteLine($"({CarCount}) A {car.Color} car has been found.");
                    CarCount++;
                }
                Console.WriteLine("\n Drive a car");
                Console.WriteLine("Delete a car");
                Console.WriteLine("Add a car");
                Console.Write("\n drive | delete | add: ");
                string Choice = Console.ReadLine()!;
                switch (Choice)
                {
                    case "drive":
                        DriveSelection();
                        break;
                    case "delete":
                        Delete();
                        break;
                    case "add":
                        AddCar();
                        break;
                    default:
                        Menu();
                        break;
                }
            }
        }

        public static void DriveSelection()
        {
            Console.Clear();
            int CarCount = 1;
            foreach (Car car in CarHandler.Cars!)
            {
                Console.WriteLine($"({CarCount}) A {car.Color} car has been found.");
                CarCount++;
            }
            Console.Write("Which car do you want to drive? (number): ");
            string Choice = Console.ReadLine()!;
            bool IsInt = int.TryParse(Choice, out int intChoice);
            if (!IsInt) { DriveSelection(); }
            else if (intChoice < CarCount && intChoice > 0)
            {
                View.Drive(CarHandler.Cars[intChoice-1]);
            }
            else { Console.Clear(); Console.WriteLine("Invalid car."); Console.ReadKey(); Menu(); }
        }

        public static void Delete()
        {
            Console.Clear();
            int CarCount = 1;
            foreach (Car car in CarHandler.Cars!)
            {
                Console.WriteLine($"({CarCount}) A {car.Color} car has been found.");
                CarCount++;
            }
            Console.Write("Which car do you want to delete? (number): ");
            string Choice = Console.ReadLine()!;
            bool IsInt = int.TryParse(Choice, out int intChoice);
            if (!IsInt) { DriveSelection(); }
            else if (intChoice < CarCount && intChoice > 0)
            {
                CarHandler.Cars.RemoveAt(intChoice);
                Menu();
            }
            else { Console.Clear(); Console.WriteLine("Invalid car."); Console.ReadKey(); Menu(); }
        }

        public static void AddCar()
        {
            Console.WriteLine("Input the color car you want to add:\n\n");
            Console.WriteLine("Red\nGreen\nBlue\nYellow\nPink\nOrange\nWhite\nBlack");
            string Choice = Console.ReadLine()!;
            switch (Choice)
            {
                case "red":
                    Add(Color.Red);
                    break;
                case "green":
                    Add(Color.Green);
                    break;
                case "blue":
                    Add(Color.Blue);
                    break;
                case "yellow":
                    Add(Color.Yellow);
                    break;
                case "pink":
                    Add(Color.Pink);
                    break;
                case "orange":
                    Add(Color.Orange);
                    break;
                case "white":
                    Add(Color.White);
                    break;
                case "black":
                    Add(Color.Black);
                    break;
                default:
                    Menu();
                    break;
            }

            static void Add(Color color)
            {
                Car car = new Car();
                car.Color = color;
                CarHandler.Cars!.Add(car);

                Menu();
            }
        }
    }
}
