using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask
{
    public class Utils
    {
        public static bool UserCheck(string message)
        {
            while (true){
                Console.WriteLine(message + "(y/n)");
                string inpt = Console.ReadLine();
                if (inpt == "y")
                {
                    return true;
                }
                else if (inpt == "n")
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
        }

        public static string TruncateString(string str, int maxlength)
        {
            return (str.Length <= maxlength) ? str : (str.Substring(0, maxlength - 3) + "...");
        }

        public static string CheckUserInput(string message, bool stringCheck = false)
        {
            while (true)
            {
                Console.Write(message);
                string data = Console.ReadLine();
                if (data == "")
                {
                    Console.Write("Cant be null!\n");
                    continue;
                }
                else if (int.TryParse(data, out _) && stringCheck)
                {
                    Console.Write("Cant be number!\n");
                    continue;
                }
                else
                {
                    return data;
                }
            }
        }
    }
}
