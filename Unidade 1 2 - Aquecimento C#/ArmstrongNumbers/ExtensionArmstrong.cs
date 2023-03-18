using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    internal static class ExtensionArmstrong
    {
        internal static bool IsArmstrong(this Armstrong entity)
        {
            var numberstr = entity.number.ToString();
            var houses = numberstr.Length;
            var single = numberstr.ToCharArray();

            double sum = 0;
            foreach (var numchar in single)
            {
                int num = int.Parse(numchar.ToString());
                sum += Math.Pow(num, houses);
            }
            if (sum == entity.number) return true; else return false;
        }
    }
}
