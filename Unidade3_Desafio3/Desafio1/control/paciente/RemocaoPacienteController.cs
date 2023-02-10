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
        public ViewCadastro ViewCadastro { get; set; }

        public RemocaoPacienteController()
        {
            ViewCadastro = new();
        }


        public void RemocaoPaciente()
        {
            ViewController.AbrirRemocaoPaciente();

            //dbcontext where cpf == ViewCadastro.Entrada
            ViewMensagens.ExibeMensagemRemocaoPaciente(true);

            // se não...
        }
    }
}
