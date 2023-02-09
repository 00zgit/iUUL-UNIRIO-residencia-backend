using Consultorio.Controller;
using Consultorio.Model;
using Consultorio.View;
using ConsultorioOdontoDB.Model.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontoDB.Controller
{
    public class CadastroPacienteController
    {
        public CadastroPacienteController() { }

        public void CadastramentoPaciente()
        {
            PacienteForm pacienteForm = new();

            pacienteForm = ViewCadastro.CadastroPaciente(pacienteForm, gerenciaPaciente);

            Paciente p = new(pacienteForm.Nome, pacienteForm.CPF, DateTime.Parse(pacienteForm.DataNascimento));

            gerenciaPaciente.Pacientes.Add(p);

            ViewMensagens.ExibeMensagemCadastroPaciente();
        }
    }
}
