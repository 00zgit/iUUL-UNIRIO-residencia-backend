using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioDB.dao
{
    public static class ConsultaDAO
    {
        internal static List<Consulta> DeletarConsulta(List<Consulta> consultas, ConsultaForm cf)
        {
            var dataAgora = DateOnly.FromDateTime(DateTime.Now);
            var dataForm = DateOnly.FromDateTime(DateTime.Parse(cf.DataConsulta));

            if (dataAgora.CompareTo(dataForm) < 0 || dataAgora.CompareTo(dataForm) == 0)
            {
                foreach (var c in consultas)
                {
                    if (c.CPF == cf.CPF
                        && c.DataConsulta == dataForm
                        && c.HoraInicial == cf.HoraInicial)
                    {
                        consultas.Remove(c);
                        return consultas;
                    }
                }
            }

            throw new Exception();
        }
    }
}
