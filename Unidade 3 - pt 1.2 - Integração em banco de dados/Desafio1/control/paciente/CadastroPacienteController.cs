using Consultorio.Model;
using Consultorio.View;
using ConsultorioOdontoDB.control;
using ConsultorioOdontoDB.db;
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
        public ContextController ContextController;

        public CadastroPacienteController()
        {
            ViewCadastro = new();
            ContextController = new();
        }


        public void CadastramentoPaciente()
        {
            ViewController.AbrirCadastroPaciente();

            if (!ContextController.ExistePaciente(ViewCadastro.PacienteForm.CPF))
            {
                ContextController.CadastrarPaciente(ViewCadastro.PacienteForm);
                ViewMensagens.ExibeMensagemCadastroPaciente();
            }
            else
                ViewMensagens.ExibeMensagemErroCPFCadastrado(true);
        }
    }
}
