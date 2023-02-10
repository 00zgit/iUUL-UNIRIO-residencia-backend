using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Consultorio.Model;
using Consultorio.Validators;
using ConsultorioOdontoDB.Model.Form;
using ConsultorioOdontoDB.validators;

namespace Consultorio.View
{
    public class ViewCadastro
    {
        public PacienteForm PacienteForm { get; set; }
        public ConsultaForm ConsultaForm { get; set; }

        public string Entrada { get; set; }

        public ViewCadastro() { }


        /********************************************
         *      Cadastramento de um paciente!       *
         *******************************************/
        public void CadastroPaciente()
        {
            PacienteForm = new();
            

            /* CPF */
            InsereCPFValido();
            PacienteForm.CPF = Entrada;


            /* NOME */
            InsereNomeValido();
            PacienteForm.Nome = Entrada;


            /* DATA DE NASCIMENTO */
            InsereDataNascimentoValida();
            PacienteForm.DataNascimento = Entrada;
        }
        /********************************************
         *      Agendamento de uma consulta!       *
         *******************************************/
        public void InsereDadosConsulta()
        {
            ConsultaForm = new();
            


            /* CPF DO PACIENTE */
            InsereCPFValido();
            ConsultaForm.CPF = Entrada;


            /* DATA DA CONSULTA */
            InsereDataConsultaValida();
            ConsultaForm.DataConsulta = Entrada;


            /* HORAS INICIAL E FINAL */
            /****************
             * SWITCH CASE
             * 1 p/ INICIAL
             * 2 p/ FINAL
             ****************/
            HORA:
            InsereHoraValida(1);
            ConsultaForm.HoraInicial = Entrada;

            InsereHoraValida(2);
            ConsultaForm.HoraFinal = Entrada;

            if (!ValidaAgendaForm.HoraValida(ConsultaForm.HoraInicial, ConsultaForm.HoraFinal))
            {
                ViewMensagens.ExibeMensagemErroHora();
                goto HORA;
            }
        }
        /****************************************
         *    Cancelamento de uma consulta!     *
         ***************************************/
        public void InsereDadosCancelamentoConsulta()
        {
            ConsultaForm = new();
            

            /* CPF */
            InsereCPFValido();
            ConsultaForm.CPF = Entrada;

            /* DATA DA CONSULTA */
            InsereDataConsultaValida();
            ConsultaForm.DataConsulta = Entrada;

            /* HORA INICIAL */
            InsereHoraValida(1);
            ConsultaForm.HoraInicial = Entrada;
        }






        /***************************************
         * FUNÇÕES DE INSERÇÃO com VALIDAÇÃO!! *
         **************************************/
        public void InsereDataNascimentoValida()
        {
            bool v = true;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroIdadePaciente();

                Console.Write("Data de Nascimento: ");
                Console.ReadLine();

                v = ValidaPacienteForm.IsDataNascimento(Entrada);
            } while (!v);
        }
        public void InsereNomeValido()
        {
            bool v = true;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroNome();

                Console.Write("Nome: ");
                Console.ReadLine();

                v = ValidaPacienteForm.IsNome(Entrada);
            } while (!v);
        }

        public void InsereCPFValido()
        {
            bool v = true;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroCPF();

                Console.Write("\nCPF: ");
                Console.ReadLine();

                v = ValidaPacienteForm.ValidaCPF(Entrada);
            } while (!v);
        }

        /****************
         * SWITCH CASE
         * 1 p/ INICIAL
         * 2 p/ FINAL
         ****************/
        public void InsereHoraValida(int s)
        {
            string texto = "";

            switch (s)
            {
                case 1: texto = "inicial";
                    break;
                case 2: texto = "final";
                    break;
            }
            
            do
            {
                Console.Write($"Hora {texto}: ");
                Console.ReadLine();

            } while (!ValidaAgendaForm.ValidaHora(Entrada, s));
        }

        /* 
         * FUNÇÃO PARA INSERÇÃO COM VERIFICAÇÃO DE DATA 
         * PARA AGENDAMENTO E CANCELAMENTO DE CONSULTAS.
         */
        public void InsereDataConsultaValida()
        {
            do
            {
                Console.Write("Data da consulta: ");
                Console.ReadLine();

            } while (!ValidaAgendaForm.ValidaDataConsulta(Entrada));
        }


        /* FUNÇÃO PARA INSERIR DATAS PARA LISTAGEM DA AGENDA POR PERÍODO */
        public string[] InsereDataInicialFinalValida()
        {
            string[] dataInicialFinal = new string[2];
            
            bool v = true;
            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroData();
                Console.Write("Data inicial: ");
                Console.ReadLine();

                v = ValidaAgendaForm.DataValida(Entrada);
            } while (!v);
            
            dataInicialFinal[0] = Entrada;
            
            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroData();
                Console.Write("Data final: ");
                Console.ReadLine();

                v = ValidaAgendaForm.DataValida(Entrada);
            } while (!v);

            dataInicialFinal[1] = Entrada;

            return dataInicialFinal;
        }
    }
}
