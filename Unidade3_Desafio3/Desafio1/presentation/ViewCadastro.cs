using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Consultorio.Controller;
using Consultorio.Model;
using Consultorio.Validators;
using ConsultorioOdontoDB.Model.Form;

namespace Consultorio.View
{
    public class ViewCadastro
    {
        public PacienteForm PacienteForm { get; set; }
        public ConsultaForm ConsultaForm { get; set; }

        public ViewCadastro() { }


        /********************************************
         *      Cadastramento de um paciente!       *
         *******************************************/
        public void CadastroPaciente()
        {
            PacienteForm = new();
            string entrada;

            /* CPF */
            entrada = InsereCPFValido();
            PacienteForm.CPF = entrada;


            /* NOME */
            entrada = InsereNomeValido();
            PacienteForm.Nome = entrada;


            /* DATA DE NASCIMENTO */
            entrada = InsereDataNascimentoValido();
            PacienteForm.DataNascimento = entrada;
        }


        /********************************************
         *      Agendamento de uma consulta!       *
         *******************************************/
        public void InsereDadosConsulta()
        {
            ConsultaForm = new();
            string entrada;


            /* CPF DO PACIENTE */
            entrada = InsereCPFValidoExistente(gerenciaPaciente,PacienteForm);
            ConsultaForm.CPF = entrada;


            /* DATA DA CONSULTA */
            entrada = InsereDataConsultaValida();
            ConsultaForm.DataConsulta = entrada;


            /* HORAS INICIAL E FINAL */
            /****************
             * SWITCH CASE
             * 1 p/ INICIAL
             * 2 p/ FINAL
             ****************/
            HORA:
            entrada = InsereHoraValida(1);
            ConsultaForm.HoraInicial = entrada;

            entrada = InsereHoraValida(2);
            ConsultaForm.HoraFinal = entrada;

            if (!ValidaAgendaForm.HoraValida(ConsultaForm.HoraInicial, ConsultaForm.HoraFinal))
            {
                ViewMensagens.ExibeMensagemErroHora();
                goto HORA;
            }
        }


        /****************************************
         *    Cancelamento de uma consulta!     *
         ***************************************/
        internal static ConsultaForm InsereDadosCancelamentoConsulta()
        {
            string? entrada;

            /* CPF */
            entrada = InsereCPFValidoExistente(gerenciaPaciente,PacienteForm);
            ConsultaForm.CPF = entrada;

            /* DATA DA CONSULTA */
            entrada = InsereDataConsultaValida();
            ConsultaForm.DataConsulta = entrada;

            /* HORA INICIAL */
            entrada = InsereHoraValida(1);
            ConsultaForm.HoraInicial = entrada;

            return ConsultaForm;
        }






        /***************************************
         * FUNÇÕES DE INSERÇÃO com VALIDAÇÃO!! *
         **************************************/
        private static string InsereDataNascimentoValido()
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroIdadePaciente();

                Console.Write("Data de Nascimento: ");
                entrada = Console.ReadLine();

                v = PacienteForm.IsDataNascimento(entrada);
            } while (!v);

            return entrada;
        }
        public static string InsereNomeValido()
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroNome();

                Console.Write("Nome: ");
                entrada = Console.ReadLine();

                v = PacienteForm.IsNome(entrada);
            } while (!v);

            return entrada;
        }

        private string InsereCPFValido()
        {
            bool v = true;
            string entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroCPF();

                Console.Write("\nCPF: ");
                entrada = Console.ReadLine();

                v = PacienteForm.ValidaCPF(entrada);
            } while (!v);

            return entrada;
        }

        /****************
         * SWITCH CASE
         * 1 p/ INICIAL
         * 2 p/ FINAL
         ****************/
        internal static string InsereHoraValida(int s)
        {
            string? texto = null;
            switch (s)
            {
                case 1: texto = "inicial";
                    break;
                case 2: texto = "final";
                    break;
            }

            string? entrada;
            do
            {
                Console.Write($"Hora {texto}: ");
                entrada = Console.ReadLine();

            } while (!ValidaAgendaForm.ValidaHora(entrada, s));


            return entrada;
        }

        /* 
         * FUNÇÃO PARA INSERÇÃO COM VERIFICAÇÃO DE DATA 
         * PARA AGENDAMENTO E CANCELAMENTO DE CONSULTAS.
         */
        private static string InsereDataConsultaValida()
        {
            string? entrada;
            do
            {
                Console.Write("Data da consulta: ");
                entrada = Console.ReadLine();

            } while (!ValidaAgendaForm.ValidaDataConsulta(entrada));

            return entrada;
        }


        /* FUNÇÃO PARA INSERIR DATAS PARA LISTAGEM DA AGENDA POR PERÍODO */
        internal static string[] InsereDataInicialFinalValida()
        {
            string[] dataInicialFinal = new string[2];

            string? entrada;
            bool v = true;
            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroData();
                Console.Write("Data inicial: ");
                entrada = Console.ReadLine();

                v = ValidaAgendaForm.DataValida(entrada);
            } while (!v);
            
            dataInicialFinal[0] = entrada;
            
            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroData();
                Console.Write("Data final: ");
                entrada = Console.ReadLine();

                v = ValidaAgendaForm.DataValida(entrada);
            } while (!v);

            dataInicialFinal[1] = entrada;

            return dataInicialFinal;
        }
    }
}
