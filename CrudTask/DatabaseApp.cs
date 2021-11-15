using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask
{
    public class DatabaseApp : ConsoleMenuApp
    {
        ISoftwareRepository data;

        public DatabaseApp(ISoftwareRepository repo)
        {
            data = repo;
        }

        protected override void AppSetup()
        {
            ConsoleMenu hw = new ConsoleMenu("Hardware");
            menus.Add(hw);

            hw.RegisterMenuItem("List hardware", HwList);
            hw.RegisterMenuItem("Find hardware", Search);
            hw.RegisterMenuItem("Add hardware", Add);
            hw.RegisterMenuItem("Change hardware", Change);
            hw.RegisterMenuItem("Delete hardware", Delete);
            hw.RegisterMenuItem("Delete ALL", DeleteAll);
            hw.RegisterMenuItem("Save ALL", SaveAll);
            hw.RegisterMenuItem("Read File", ReadFile);
            hw.RegisterMenuItem("Export to XML", ExportToXML);
            hw.RegisterMenuItem("Export to HTML", ExportToHTML);
#if DEBUG
            hw.RegisterMenuItem("Add test data", AddTestData);
            #endif

            AddExitToMenu(hw);

            RegisterSubmenu(main_menu, hw, "Hardware management");
        }

        void HwList()
        {
            Console.WriteLine("Listing hardware...");

            StringBuilder sb = new StringBuilder(120);

            string border = sb.ToString();
            string header = FormatTableEntry("Manufacturer", "Name", "Model", "Type");
            
            Console.WriteLine(border);
            Console.WriteLine(header);
            Console.WriteLine(border);
            
            foreach (Hardware hw in data.GetList())
            {
                Console.WriteLine(FormatTableEntry(hw.Manufacturer, hw.Name, hw.Model, hw.Type));
                Console.WriteLine(border);
            }
        }

        string FormatTableEntry(string manufacturer, string name, string Model, string Type)
        {
            StringBuilder sb = new StringBuilder(80);

            sb.Append("| ");
            sb.Append($"{Utils.TruncateString(manufacturer, 15),-15}");
            sb.Append(" | ");
            sb.Append($"{Utils.TruncateString(name, 15),-15}");
            sb.Append(" | ");
            sb.Append($"{Utils.TruncateString(Model, 10),-10}");
            sb.Append(" | ");
            sb.Append($"{Utils.TruncateString(Type, 30),-30}");
            sb.Append(" | ");

            return sb.ToString();
        }


        void Add()
        {
            string manufacturer = Utils.CheckUserInput("Manufacturer - ", true);
            string name = Utils.CheckUserInput("Name - ", true);
            string model = Utils.CheckUserInput("Model - ");

            Hardware hw = new Hardware()
            {
                Manufacturer = manufacturer,
                Name = name,
                Model = model
            };

            data.Add(hw);

            Console.WriteLine("Adding hardware...");
        }

        void Change()
        {
            Console.WriteLine("Changing hardware...");
            foreach (Hardware hw in data.GetList())
            {
                Console.WriteLine($"{hw.Manufacturer}\t{hw.Name}\t{hw.Model}\t{hw.Type}");
            }
            Console.WriteLine("Hardware Index: ");
            int index = -1;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out index))
                {
                    Console.WriteLine("Invalid pos");
                }
                else break;
            }
            Console.WriteLine("Field name(manufacturer, name, model, type):");
            while (true){
                string field = Console.ReadLine();
                switch (field)
                {
                    case "manufacturer":
                        Console.WriteLine("Enter Manufacturer:");
                        data.GetList().ToList()[index-1].Manufacturer = Console.ReadLine();
                        return;
                    case "name":
                        Console.WriteLine("Enter Name:");
                        data.GetList().ToList()[index-1].Name = Console.ReadLine();
                        return;
                    case "model":
                        Console.WriteLine("Enter Model:");
                        data.GetList().ToList()[index-1].Model = Console.ReadLine();
                        return;
                    case "type":
                        Console.WriteLine("Enter Type:");
                        data.GetList().ToList()[index-1].Type = Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Invalid field name:");
                        continue;
                }
            }
        }

        void Delete()
        {
            Console.Write("Hardware pos - ");
            string str = Console.ReadLine();
            if (int.TryParse(str, out int index))
            {
                if (index >= 1)
                {
                    if (data.GetList().ToList().Count > index - 1 && Utils.UserCheck($"Delete data at pos {index}?"))
                    {
                        data.RemoveAt(index);
                        Console.WriteLine("Deleting hardware...");
                    }
                    else
                    {
                        Console.WriteLine("Int is biger than hardware count");
                    }
                }
                else
                {
                    Console.WriteLine("Int is negative or zero");
                }
            }
            else
            {
                Console.WriteLine("Str is not int");
            }
        }

        void DeleteAll()
        {
            if (Utils.UserCheck("Delete all data?"))
            {
                data.RemoveAll();
            }
            else
            {
                Console.WriteLine("Action aborted");
            }
        }

        void SaveAll()
        {
            if (Utils.UserCheck("Save all data?"))
            {
                data.SaveChanges();
            }
            else
            {
                Console.WriteLine("Action aborted");
            }
        }

        void AddTestData()
        {
            data.Add(new Hardware()
            {
                Manufacturer = "MSI",
                Name = "GeForce® GTX",
                Model = "1070",
                Type = "Graphic card"
            });
            Console.WriteLine("Adding test data");
        }

        void ReadFile()
        {
            data.ReadFile();
        }

        void Search()
        {
            List<Hardware> hwList = data.Search(Utils.CheckUserInput("Name - "));
            if (hwList.Count() == 0)
            {
                Console.WriteLine("Nothing found");
                return;
            }
            foreach (Hardware hw in hwList)
            {
                Console.WriteLine(FormatTableEntry(hw.Manufacturer, hw.Name, hw.Model, hw.Type));
            }
        }

        void ExportToXML()
        {
            data.ExportToXML();
            Console.WriteLine("Exporting to XML");
        }

        void ExportToHTML()
        {
            data.ExportToHTML();
            Console.WriteLine("Exporting to HTML");
        }

        protected override void AppExit()
        {
            if (Utils.UserCheck("Save changes?"))
            {
                data.SaveChanges();
            }
            Console.WriteLine("Exiting...");
            running = false;
        }
    }
}
