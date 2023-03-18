using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    public class IndiceRemissivo
    {
        public static string[] IgnoreToUpperArray(string ignore)
        {
            ignore = ignore.ToUpper();
            string[] words = ignore.Split('\n');
            return words;
        }
        public static string[] TxtToUpperSortedArray(string txt)
        {
            txt = txt.ToUpper();
            string[] words = txt.Split(' ');
            Array.Sort(words);
            return words;
        }
        public static Dictionary<string,int> Calcula(string[] txt, string[] ignore)
        {
            string aux;
            int wordCount = 1;
            bool isPresent = false;
            Dictionary<string, int> indices = new();

            // para toda palavra do texto
            for(int i = 0; i < txt.Length; ++i)
            {
                aux = txt[i];
                // vamos comparar com as que devem ser ignoradas
                for (int k = 0; k < ignore.Length; ++k)
                    if (aux == ignore[k])
                        isPresent = true;

                if (!isPresent)
                {
                    if (!indices.ContainsKey(aux))
                    {
                        indices.Add(aux, wordCount);
                        wordCount = 1;
                    }
                    else ++wordCount;
                }
                isPresent = false;
            }

            return indices;
        }
    }
}
