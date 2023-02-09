using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioDB
{
    internal static class ViewMensagens
    {
        /************
         * PACIENTE *
         ***********/
        public static void ExibeMensagemCadastroPaciente()
        {
            Console.WriteLine("\nPaciente cadastrado com sucesso!");
        }
        public static void ExibeMensagemRemocaoPaciente(bool v)
        {
            if(v) Console.WriteLine("\nPaciente excluído com sucesso!");
            else Console.WriteLine("\nErro: paciente está agendado.");
        }
        public static void ExibeMensagemErroIdadePaciente()
        {
            Console.WriteLine("\nErro: paciente precisa ter pelo menos 13 anos.\n");
        }

        /**********
         * AGENDA *
         *********/
        internal static void ExibeMensagemAgendamento(bool v)
        {
            if(v) Console.WriteLine("\nAgendamento realizado com sucesso");
            else Console.WriteLine("\nErro: horário indisponível ou paciente já possui consulta futura agendada.");
        }
        internal static void ExibeMensagemErroHorarioComercial()
        {
            Console.WriteLine("\nErro: horário inserido fora do horário comercial (08h às 19h).\n");
        }
        internal static void ExibeMensagemErroHorarioMinutos()
        {
            Console.WriteLine("\nErro: horário inserido precisa ser marcado de 15 em 15 minutos.\n");
        }
        internal static void ExibeMensagemCancelarConsulta(bool v)
        {
            if (v) Console.WriteLine("\nConsulta desmarcada com sucesso.");
            else Console.WriteLine("\nErro: Não há consultas marcadas nesta data.");
        }
        internal static void ExibeMensagemErroCancelarConsultaAntiga()
        {
            Console.WriteLine("\nErro: Não é possível escolher uma consulta com data passada.\n");
        }
        internal static void ExibeMensagemErroHora()
        {
            Console.WriteLine("\nErro: hora inválida.\n");
        }
        internal static void ExibeMensagemErroData()
        {
            Console.WriteLine("\nErro: data inválida.\n");
        }
        internal static void ExibeMensagemErroHorarioInicial()
        {
            Console.WriteLine("\nErro: hora inicial deve ser anterior às 19h.\n");
        }
        internal static void ExibeMensagemErroHorarioFinal()
        {
            Console.WriteLine("\nErro: hora final deve ser posterior às 08h.\n");
        }

        /*******
         * CPF *
         ******/
        internal static void ExibeMensagemErroCPF()
        {
            Console.WriteLine("\nErro: CPF inválido.");
        }
        internal static void ExibeMensagemErroCPFCadastrado(bool v)
        {
            if (!v) Console.WriteLine("\nErro: CPF não cadastrado.");
            else Console.WriteLine("\n Erro: CPF já está cadastrado");
        }

        /********
         * Nome *
         *******/
        internal static void ExibeMensagemErroNome()
        {
            Console.WriteLine("\nErro: nome deve ter pelo menos 05 (cinco) caracteres.\n");
        }
    }
}
