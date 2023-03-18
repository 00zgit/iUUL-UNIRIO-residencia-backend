using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    public static class ExtensionGenericList
    {
        public static List<T> RemoveRepetido<T>(this IList<T> list)
        {
            return list.ToHashSet().ToList();
        }
    }
}
