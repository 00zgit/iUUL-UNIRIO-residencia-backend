using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    public class View
    {
        public static string ReadTxt()
        {
            using StreamReader reader = new(@$"{AppContext.BaseDirectory}\texto.txt");
            return reader.ReadToEnd();
        }
        public static string ReadIgnore()
        {
            using StreamReader reader = new(@$"{AppContext.BaseDirectory}\ignore.txt");
            return reader.ReadToEnd();
        }
        public static void Imprime(Dictionary<string, int> indices)
        {
            foreach(var i in indices)
            {
                Console.WriteLine($"{i.Key} ({i.Value})");
            }
        }
    }
}
