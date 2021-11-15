using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = "hardware";
                if (args.Length >= 1)
                {
                    char dot = '.';
                    filename = args[1].Split(dot)[0];
                }
                JsonFileSoftwareRepository repo = new JsonFileSoftwareRepository(filename);
                ConsoleMenuApp app = new DatabaseApp(repo);
                app.Setup();
                app.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fatal error: {e.Message}\n{e.StackTrace}");
                Console.ReadKey();
            }
        }
    }
}
