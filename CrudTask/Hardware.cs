using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CrudTask
{
    public class Hardware
    {
        private string manufacturer;
        private string name;
        private string model;
        private string type;

        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Name { get => name; set => name = value; }
        public string Model { get => model; set => model = value; }
        public string Type { get => type; set => type = value; }

        public static List<Hardware> ReadJson(string filename)
        {
            string json;
            List<Hardware> data = new List<Hardware>();

            if (File.Exists($"{filename}.json"))
            {
                using (StreamReader file = new StreamReader($"{filename}.json"))
                {
                    json = file.ReadToEnd();
                }
                data = JsonConvert.DeserializeObject<List<Hardware>>(json);
            }
            else
            {
                File.WriteAllText($"{filename}.json", "[]");
            }
            return data;
        }

        public static void WriteJson(string filename, List<Hardware> data)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText($"{filename}.json", json);
        }

        public static void WriteXML(string name, List<Hardware> data)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter wr = XmlWriter.Create($"{name}.xml", settings))
            {
                wr.WriteStartDocument();
                wr.WriteStartElement("Hardwares");
                foreach (Hardware hw in data)
                {
                    wr.WriteStartElement("Hardware");

                    wr.WriteAttributeString("Manufacturer", $"{hw.Manufacturer}");
                    wr.WriteElementString("Name", $"{hw.Name}");
                    wr.WriteElementString("Model", $"{hw.Model}");
                    wr.WriteElementString("Type", $"{hw.Type}");

                    wr.WriteEndElement();
                }
                wr.WriteEndElement();
                wr.WriteEndDocument();
            }
        }

        public static void WriteHTML(string name, List<Hardware> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr>");
            sb.Append("<th>Manufacturer</th>");
            sb.Append("<th>Name</th>");
            sb.Append("<th>Model</th>");
            sb.Append("<th>Type</th>");
            sb.Append("</tr>");
            foreach (Hardware hw in data)
            {
                sb.Append("<tr>");
                sb.Append($"<th>{hw.Manufacturer}</th>");
                sb.Append($"<th>{hw.Name}</th>");
                sb.Append($"<th>{hw.Model}</th>");
                sb.Append($"<th>{hw.Type}</th>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            File.WriteAllText($"{name}.html", sb.ToString());
        }
    }
}
