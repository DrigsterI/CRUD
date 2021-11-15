using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask
{
    // Интерфейс = класс, в котором есть только публичные виртуальные методы без реализации
    // Repository - паттерн (шаблон) проектирования
    // описывающий абстрагированный доступ к хранилищу какого-то рода объектов
    public interface ISoftwareRepository
    {
        IEnumerable<Hardware> GetList();
        void Add(Hardware sw);
        void Remove(Hardware sw);
        void RemoveAt(int index);
        void RemoveAll ();
        void ReadFile(string name = null);
        List<Hardware> Search(string name);
        void ExportToXML(string name = null);
        void ExportToHTML(string name = null);
        void SaveChanges(string name = null);
    }
}
