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
    public class AdicionarConsultaController
    {
        public AdicionarConsultaController() { }

        public void CriacaoConsulta()
        {
            ConsultaForm consultaForm = new();
            PacienteForm pf = new();
            consultaForm = ViewCadastro.InsereDadosConsulta(gerenciaPaciente, consultaForm, pf);

            //Verificar se o cpf inserido para consulta está cadastrado no sistema
            Paciente? paciente = gerenciaPaciente.RetornaPaciente(consultaForm.CPF);
            if (paciente == null)
            {
                ViewMensagens.ExibeMensagemErroCPFCadastrado(false);
                break;
            }

            // Se estiver, verificar sobreposição de consultas
            Consulta consulta = new(consultaForm.CPF,
                DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta)),
                consultaForm.HoraInicial, consultaForm.HoraFinal);
            try
            {
                paciente.Consulta = consulta;
            }
            catch
            {
                // Exibir mensagem de erro
                ViewMensagens.ExibeMensagemAgendamento(false);
                break;
            }

            // Adicionando consulta na agenda
            Agenda.Consultas.Add(consulta);

            // Exibir mensagem de sucesso
            ViewMensagens.ExibeMensagemAgendamento(true);
        }
    }
}
