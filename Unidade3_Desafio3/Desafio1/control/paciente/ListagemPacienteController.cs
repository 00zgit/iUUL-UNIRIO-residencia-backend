using Consultorio.View;
using ConsultorioOdontoDB.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontoDB.control.paciente
{
    public class ListagemPacienteController
    {
        public ViewCadastro ViewCadastro { get; set; }
        public ListagemPacienteController()
        {
            ViewCadastro = new();
        }

        public void ListagemPacienteCPF()
        {
            ContextController.ConsultarListaDePacientes();
            //ordenar e mandar pra view
        }

        public void ListagemPacienteNome()
        {
            ContextController.ConsultarListaDePacientes();
            //ordenar e mandar pra view
        }
    }
}
