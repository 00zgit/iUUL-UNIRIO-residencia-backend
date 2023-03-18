using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01
{   
    internal class ListaIntervalo
    {
        public List<Intervalo> Intervalos = new List<Intervalo>();

        public bool AddIntervalo(Intervalo i)
        {
            foreach(Intervalo intervalo in Intervalos)
            {
                if(intervalo.TemIntersecao(i)) return false;
            }
            Intervalos.Add(i);
            return true;
        }

        public void ImprimeIntervalo(ListaIntervalo li)
        {
            foreach (Intervalo intervalo in li.Intervalos)
            {
                Console.WriteLine(intervalo.initTime);
            }
        }
    }
}
