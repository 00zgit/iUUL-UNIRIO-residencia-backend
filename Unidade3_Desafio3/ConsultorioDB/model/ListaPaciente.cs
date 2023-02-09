using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioDB.model
{
    public class ListaPaciente
    {
        public List<Paciente> Pacientes { get; set; }

        public ListaPaciente()
        {
            Pacientes = new List<Paciente>();
        }

        public void AdicionarPacienteNaLista(Paciente p)
        {
            Pacientes.Add(p);
        }
    }
}
