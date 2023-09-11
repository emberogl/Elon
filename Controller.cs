using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elon
{   
    /// <summary>
    /// This might be the controller class, but it's very challenging for me to
    /// figure out how to properly separate view (console writelines) from immediate logic.
    /// 
    /// I can see how MVC would be applied to complex API structures, but I'm not sure
    /// how to go about it in simple console-based applications.
    /// </summary>
    internal class Controller
    {
        // Begins menu interaction.
        public static void Start() 
        {
            View.Menu();
        }

        // Lets user select to drive a car from the list they have created.
        public static void DriveSelection()
        {
            Console.Clear();
            int CarCount = 1;
            foreach (Car car in Model.Cars!)
            {
                Console.WriteLine($"({CarCount}) A {car.Color} car has been found.");
                CarCount++;
            }
            Console.Write("\nWhich car do you want to drive? (number): ");
            string Choice = Console.ReadLine()!;
            bool IsInt = int.TryParse(Choice, out int intChoice);
            if (!IsInt) { View.InvalidMessage(); }
            else if (intChoice < CarCount && intChoice > 0)
            {
                View.Drive(Model.Cars[intChoice-1]);
            }
            else { View.InvalidMessage(); }
        }

        // Lets user delete a car from the list they have created.
        public static void DeleteCar()
        {
            Console.Clear();
            int CarCount = 1;
            foreach (Car car in Model.Cars!)
            {
                Console.WriteLine($"({CarCount}) A {car.Color} car has been found.");
                CarCount++;
            }
            Console.Write("\nWhich car do you want to delete? (number): ");
            string Choice = Console.ReadLine()!;
            bool IsInt = int.TryParse(Choice, out int intChoice);
            if (!IsInt) { DriveSelection(); }
            else if (intChoice == 1 && Model.Cars.Count == 1)
            {
                Model.Cars.RemoveAt(0);
                Model.DeleteFile(); // Gets rid of file since all cars have been deleted.
                View.Menu();
            }
            else if (intChoice < CarCount && intChoice > 0)
            {
                Model.Cars.RemoveAt(intChoice - 1);
                Model.ExportCars(); // Reflects car list update on disk file.
                View.Menu();
            }
            else { View.InvalidMessage(); }
        }

        // Lets user add a car with a color to the list.
        public static void AddCar()
        {
            Console.Clear();
            Console.WriteLine("Input the color car you want to add:\n");
            Console.WriteLine("red\ngreen\nblue\nyellow\npink\norange\nwhite\nblack\n");
            string Choice = Console.ReadLine()!;
            if (Model.ColorIndex.Contains(Choice))
            {
                Add(Choice);
            }
            else
            {
                View.InvalidMessage();
                View.Menu();
            }

            static void Add(string color)
            {
                Car car = new Car();
                car.Color = color;
                Model.Cars!.Add(car);
                Model.ExportCars(); // Reflects car list update on disk file.
                View.Menu();
            }
        }
    }
}
