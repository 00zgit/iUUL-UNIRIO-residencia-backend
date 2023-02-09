using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioDB.dao
{
    public static class AgendaDAO
    {
        public static List<Consulta> RetornaAgenda(Agenda a)
        {
            return a.Consultas;
        }

        public static void AtualizaAgenda(Agenda a,List<Consulta> consultas)
        {
            a.Consultas = consultas;
        }

        public static void AdicionaConsultaNaAgenda(Agenda a, Consulta c)
        {
            a.Consultas.Add(c);
        }
    }
}
