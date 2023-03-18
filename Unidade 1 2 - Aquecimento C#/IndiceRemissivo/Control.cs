using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    internal class Control
    {
        public static void Start()
        {
            //Read files
            string txt = View.ReadTxt();
            string ignore = View.ReadIgnore();

            //generate arrays
            string[] sortedTxt = IndiceRemissivo.TxtToUpperSortedArray(txt);
            string[] ignoreArr = IndiceRemissivo.IgnoreToUpperArray(ignore);

            //calculate remissive index
            var indices = IndiceRemissivo.Calcula(sortedTxt, ignoreArr);

            //print
            View.Imprime(indices);
        }
    }
}
