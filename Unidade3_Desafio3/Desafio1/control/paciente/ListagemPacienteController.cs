using Consultorio.Controller;
using Consultorio.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontoDB.control.paciente
{
    public class ListagemPacienteController
    {
        public ListagemPacienteController() { }

        public void ListagemPacienteCPF()
        {
            gerenciaPaciente.Pacientes.Sort((a1, a2) => a1.CPF.CompareTo(a2.CPF));
            ViewListagem.ExibeListaPacientes(gerenciaPaciente.Pacientes);
        }

        public void ListagemPacienteNome()
        {
            gerenciaPaciente.Pacientes.Sort((a1, a2) => a1.Nome.CompareTo(a2.Nome));
            ViewListagem.ExibeListaPacientes(gerenciaPaciente.Pacientes);
        }
    }
}
