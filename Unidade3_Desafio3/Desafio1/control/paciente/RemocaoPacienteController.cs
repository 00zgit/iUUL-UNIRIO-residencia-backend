using Consultorio.Controller;
using Consultorio.View;
using ConsultorioOdontoDB.Model.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontoDB.control.paciente
{
    public class RemocaoPacienteController
    {
        public RemocaoPacienteController() { }

        public void RemocaoPaciente()
        {
            PacienteForm pf = new();
            var cpfRemover = ViewCadastro.InsereCPFValidoExistente(gerenciaPaciente, pf); // Inserir um CPF.

            try
            {
                gerenciaPaciente.RemovePaciente(cpfRemover);
            }
            catch
            {
                ViewMensagens.ExibeMensagemRemocaoPaciente(false);
                break;
            }
            ViewMensagens.ExibeMensagemRemocaoPaciente(true);
        }
    }
}
