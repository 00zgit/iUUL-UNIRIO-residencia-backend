using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Consultorio.Controller;
using Consultorio.Form;
using Consultorio.Model;
using Consultorio.Validators;

namespace Consultorio.View
{
    internal static class ViewCadastro
    {
        /********************************************
         *      Cadastramento de um paciente!       *
         *******************************************/
        public static PacienteForm CadastroPaciente(PacienteForm pacienteForm, GerenciaPaciente gerenciaPaciente)
        {
            string? entrada;
            bool v = false;

            /* CPF */
            //INSERÇÃO DE CPF PARA CADASTRO -> VALIDAÇÃO CPF VÁLIDO -> VALIDAÇÃO CPF EXISTENTE NO CADASTRO
            do
            {
                if (v)
                    ViewMensagens.ExibeMensagemErroCPFCadastrado(true);

                entrada = InsereCPFValido(pacienteForm);
                v = gerenciaPaciente.ExistePaciente(entrada);
            } while (v);
            
            pacienteForm.CPF = entrada;


            /* NOME */
            entrada = InsereNomeValido(pacienteForm);
            pacienteForm.Nome = entrada;


            /* DATA DE NASCIMENTO */
            entrada = InsereDataNascimentoValido(pacienteForm);
            pacienteForm.DataNascimento = entrada;


            return pacienteForm;
        }


        /********************************************
         *      Agendamento de uma consulta!       *
         *******************************************/
        public static ConsultaForm InsereDadosConsulta(GerenciaPaciente gerenciaPaciente, ConsultaForm consultaForm,PacienteForm pf)
        {
            string? entrada;


            /* CPF DO PACIENTE */
            entrada = InsereCPFValidoExistente(gerenciaPaciente,pf);
            consultaForm.CPF = entrada;


            /* DATA DA CONSULTA */
            entrada = InsereDataConsultaValida();
            consultaForm.DataConsulta = entrada;


            /* HORAS INICIAL E FINAL */
            /****************
             * SWITCH CASE
             * 1 p/ INICIAL
             * 2 p/ FINAL
             ****************/
            HORA:
            entrada = InsereHoraValida(1);
            consultaForm.HoraInicial = entrada;

            entrada = InsereHoraValida(2);
            consultaForm.HoraFinal = entrada;

            if (!ValidaAgendaForm.HoraValida(consultaForm.HoraInicial, consultaForm.HoraFinal))
            {
                ViewMensagens.ExibeMensagemErroHora();
                goto HORA;
            }

            return consultaForm;
        }


        /****************************************
         *    Cancelamento de uma consulta!     *
         ***************************************/
        internal static ConsultaForm InsereDadosCancelamentoConsulta(GerenciaPaciente gerenciaPaciente, ConsultaForm consultaForm,PacienteForm pf)
        {
            string? entrada;

            /* CPF */
            entrada = InsereCPFValidoExistente(gerenciaPaciente,pf);
            consultaForm.CPF = entrada;

            /* DATA DA CONSULTA */
            entrada = InsereDataConsultaValida();
            consultaForm.DataConsulta = entrada;

            /* HORA INICIAL */
            entrada = InsereHoraValida(1);
            consultaForm.HoraInicial = entrada;

            return consultaForm;
        }






        /***************************************
         * FUNÇÕES DE INSERÇÃO com VALIDAÇÃO!! *
         **************************************/
        private static string InsereDataNascimentoValido(PacienteForm pf)
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroIdadePaciente();

                Console.Write("Data de Nascimento: ");
                entrada = Console.ReadLine();

                v = pf.IsDataNascimento(entrada);
            } while (!v);

            return entrada;
        }
        public static string InsereNomeValido(PacienteForm pf)
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroNome();

                Console.Write("Nome: ");
                entrada = Console.ReadLine();

                v = pf.IsNome(entrada);
            } while (!v);

            return entrada;
        }


        /* ESTA FUNÇÃO RETORNA O VALOR SE ELE FOR UM CPF */
        public static string InsereCPFValido(PacienteForm pf)
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroCPF();

                Console.Write("\nCPF: ");
                entrada = Console.ReadLine();

                v = pf.ValidaCPF(entrada);
            } while (!v);

            return entrada;
        }
        /* ESTA FUNÇÃO RETORNA O VALOR SE ELE FOR UM CPF && EXISTENTE */
        public static string InsereCPFValidoExistente(GerenciaPaciente gerenciaPaciente,PacienteForm pf)
        {
            string? entrada;
            bool v = true;
            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroCPFCadastrado(false);

                entrada = InsereCPFValido(pf);

                v = gerenciaPaciente.ExistePaciente(entrada);
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
