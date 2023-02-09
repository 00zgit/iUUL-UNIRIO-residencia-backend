using Consultorio.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    internal class Agenda
    {
        public static List<Consulta>? Consultas { get; private set; }

        public Agenda()
        {
            Consultas = new List<Consulta>();
        }

        internal void RemoveConsulta(ConsultaForm consultaForm)
        {
            var dataAgora = DateOnly.FromDateTime(DateTime.Now);
            var dataForm = DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta));

            if (Consultas != null)
            {
                if(dataAgora.CompareTo(dataForm) < 0 || dataAgora.CompareTo(dataForm) == 0)
                {
                    foreach (var consulta in Consultas)
                    {
                        if (consulta.CPF == consultaForm.CPF
                            && consulta.DataConsulta == dataForm
                            && consulta.HoraInicial == consultaForm.HoraInicial)
                        {
                            Consultas.Remove(consulta);
                            return;
                        }
                    }
                }
            }

            throw new Exception();
        }
    }
}
