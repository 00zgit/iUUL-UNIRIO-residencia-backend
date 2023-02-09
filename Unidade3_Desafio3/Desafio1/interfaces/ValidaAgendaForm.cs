using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Model;
using Consultorio.View;

namespace Consultorio.Validators
{
    internal class ValidaAgendaForm
    {
        private static readonly List<string> Horas = new()
        {
            "08","09","10","11",
            "12","13","14","15",
            "16","17","18","19"
        };
        private static readonly List<string> Minutos = new()
        {
            "00","15","30","45"
        };

        /************************/
        /*  VALIDAÇÃO DE HORAS  *
         * **********************
         * SWITCH CASE
         * 1 p/ INICIAL
         * 2 p/ FINAL
         ***********************/
        internal static bool ValidaHora(string? entrada,int s)
        {
            if (entrada == null) return false;
            if (!HoraExistente(entrada)) return false;

            switch (s)
            {
                case 1:
                    {
                        if (entrada.Substring(0,2) == "19" && entrada.Substring(2,2) == "00")
                        {
                            ViewMensagens.ExibeMensagemErroHorarioInicial();
                            return false;
                        }
                    }
                    break;
                case 2:
                    {
                        if (entrada.Substring(0, 2) == "08" && entrada.Substring(2, 2) == "00")
                        {
                            ViewMensagens.ExibeMensagemErroHorarioFinal();
                            return false;
                        }
                    }
                    break;
            }

            return true;
        }

        private static bool HoraExistente(string entrada)
        {
            try
            {
                int.Parse(entrada);
            }
            catch
            {
                ViewMensagens.ExibeMensagemErroHora();
                return false;
            }

            var hh = entrada.Substring(0, 2);
            var mm = entrada.Substring(2, 2);

            bool verdadeiro = false;
            foreach (var enumHH in Horas)
            {
                if (hh == enumHH) verdadeiro = true;
            }
            if (!verdadeiro)
            {
                ViewMensagens.ExibeMensagemErroHorarioComercial();
                return false;
            }

            verdadeiro = false;
            foreach (var enumMM in Minutos)
            {
                if (mm == enumMM) verdadeiro = true;
            }
            if (!verdadeiro)
            {
                ViewMensagens.ExibeMensagemErroHorarioMinutos();
                return false;
            }

            return true;
        }

        

        /***********************/
        /* VALIDAÇÃO DE DATAS */
        /***********************/
        internal static bool DataValida(string? entrada)
        {
            if (entrada == null) return false;
            if (!ValidaData(entrada)) return false;

            return true;
        }
        private static bool ValidaData(string entrada)
        {
            try
            {
                DateOnly data = DateOnly.Parse(entrada);
            }
            catch
            {
                return false;
            }
            return true;
        }

        internal static bool ValidaDataConsulta(string? entrada)
        {
            if (!DataValida(entrada))
            {
                ViewMensagens.ExibeMensagemErroData();
                return false;
            }

            var agora = DateOnly.FromDateTime(DateTime.Now);
            var dtConsulta = DateOnly.FromDateTime(DateTime.Parse(entrada));

            // Não deve ser possível escolher uma consulta com data passada.
            if (dtConsulta.CompareTo(agora) < 0)
            {
                ViewMensagens.ExibeMensagemErroCancelarConsultaAntiga();
                return false;
            }
                

            return true;
        }

        /* Verificar se a hora final é anterior à hora inicial */
        internal static bool HoraValida(string horaInicial, string horaFinal)
        {
            if (int.Parse(horaFinal.Substring(0, 2)) < int.Parse(horaInicial.Substring(0, 2)))
                return false;
            return true;
        }
    }
}
