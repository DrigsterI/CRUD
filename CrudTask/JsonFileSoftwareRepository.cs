using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CrudTask
{
    // Имплементация интерфейса "Репозитарий П/О" под схему с хранением данных в CSV-файле
    public class JsonFileSoftwareRepository : ISoftwareRepository
    {
        private List<Hardware> data = new List<Hardware>();
        private string filename;

        public JsonFileSoftwareRepository(string file_name)
        {
            filename = file_name;

            data = Hardware.ReadJson(filename);
        }

        public void Add(Hardware sw)
        {
            data.Add(sw);
        }

        public IEnumerable<Hardware> GetList()
        {
            return data;
        }

        public void Remove(Hardware sw)
        {
            data.Remove(sw);
        }

        public void RemoveAt(int index)
        {
            data.RemoveAt(index);
        }

        public void RemoveAll()
        {
            data.Clear();
        }

        public void ReadFile(string name = null)
        {
            if(name == null)
            {
                name = filename;
            }

            data = Hardware.ReadJson(filename);
        }

        public List<Hardware> Search(string name)
        {
            return data.FindAll(
                delegate (Hardware hw)
                {
                    if (hw.Manufacturer.Contains(name) || hw.Model.Contains(name) || hw.Name.Contains(name) || hw.Type.Contains(name))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
        }

        public void ExportToXML(string name = null)
        {
            if (name == null)
            {
                name = filename;
            }
            Hardware.WriteXML(name, data);
        }

        public void ExportToHTML(string name = null)
        {
            if (name == null)
            {
                name = filename;
            }
            Hardware.WriteHTML(name, data);
        }

        public void SaveChanges(string name = null)
        {
            if (name == null)
            {
                name = filename;
            }
            if (File.Exists($"{name}.json"))
            {
                if (File.Exists($"{name}.json.bak"))
                {
                    File.Delete($"{name}.json.bak");
                }
                File.Move($"{name}.json", "hardware.json.bak");
            }
            Hardware.WriteJson(name, data);
        }
    }
}
