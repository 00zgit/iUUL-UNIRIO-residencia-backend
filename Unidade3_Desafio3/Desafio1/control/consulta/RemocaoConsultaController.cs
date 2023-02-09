using Consultorio.Model;
using Consultorio.View;
using ConsultorioOdontoDB.Model.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontoDB.control.consulta
{
    internal class RemocaoConsultaController
    {
        public RemocaoConsultaController() { }

        public void RemocaoConsulta()
        {
            ConsultaForm consultaForm = new();
            PacienteForm pf = new();
            consultaForm = ViewCadastro.InsereDadosCancelamentoConsulta(gerenciaPaciente, consultaForm, pf);

            try
            {
                agenda.RemoveConsulta(consultaForm);
            }
            catch
            {
                ViewMensagens.ExibeMensagemCancelarConsulta(false);
                break;
            }

            // Se o try for realizado com sucesso,
            // removemos a consulta associada ao paciente.
            Paciente? pacienteRemoverConsulta = gerenciaPaciente.RetornaPaciente(consultaForm.CPF);

            if (pacienteRemoverConsulta != null)
                pacienteRemoverConsulta.Consulta = null;

            ViewMensagens.ExibeMensagemCancelarConsulta(true);
        }
    }
}
