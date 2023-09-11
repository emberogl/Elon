using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elon
{
    /// <summary>
    /// Aside from using the list in RAM, the created cars are also being stored
    /// and retrieved from a file in this class.
    /// </summary>
    internal class Model
    {
        static readonly string Directory = AppDomain.CurrentDomain.BaseDirectory;
        static readonly string FilePath = Path.Combine(Directory, "cardata.json");

        // To avoid a long condition check, a simple lookup to confirm if the desired color exists
        public static readonly List<String> ColorIndex = new List<String>()
        {
            { "red" }, { "green" }, { "blue" }, 
            { "yellow" }, { "pink" }, { "orange" },
            { "white" }, { "black" }
        };

        // A list of cars the user creates and can select to use.
        public static List<Car>? Cars { get; set; } = new List<Car>();

        #region Storage
        public static void ExportCars()
        {

            if (Cars!.Count != 0)
            {
                string Json = JsonSerializer.Serialize(Cars);
                File.WriteAllText(FilePath, Json);
            }
        }

        public static void ImportCars()
        {
            if (File.Exists(FilePath))
            {
                string Json = File.ReadAllText(FilePath);
                Cars = JsonSerializer.Deserialize<List<Car>>(Json);
            }
        }

        public static void DeleteFile()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }
        #endregion
    }
}