using Consultorio.Model;
using Consultorio.View;
using ConsultorioOdontoDB.control;
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
        public ViewCadastro ViewCadastro;

        public CadastroPacienteController()
        {
            this.ViewCadastro = new();
        }


        public void CadastramentoPaciente()
        {
            ViewController.AbrirCadastroPaciente();

            //dbcontext (verificar se cpf ja esta cadastrado no sist)
            // se sim, cancelar operacao voltando para o menu.

            // se não,
            Paciente paciente = new(ViewCadastro.PacienteForm.Nome, ViewCadastro.PacienteForm.CPF, DateTime.Parse(ViewCadastro.PacienteForm.DataNascimento));

            // db context (add e salvar).

            ViewMensagens.ExibeMensagemCadastroPaciente();
        }
    }
}
