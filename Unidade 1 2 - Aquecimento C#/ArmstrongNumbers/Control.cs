using Q3;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    internal class Control
    {
        public static void Start()
        {
            for(int i = 1; i <= 10000; i++)
            {
                Armstrong armstrong = new();
                armstrong.number = i;
                if (armstrong.IsArmstrong()) i.PrintNumber();
            }
        }
    }
}
