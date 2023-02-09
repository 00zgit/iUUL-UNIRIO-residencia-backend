using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    internal class Consulta
    {
        public string CPF { get; private set; }
        public DateOnly DataConsulta { get; private set; }
        public string HoraInicial { get; private set; }
        public string HoraFinal { get; private set; }

        public Consulta(string cpf, DateOnly data, string h1, string h2)
        {
            this.CPF = cpf;
            this.DataConsulta = data;
            this.HoraInicial = h1;
            this.HoraFinal = h2;
        }

        internal bool PossuiAgendamentoSobreposto()
        {
            foreach (var c in Agenda.Consultas)
            {
                if (c.DataConsulta == this.DataConsulta)
                {
                    // 1 - Se a hora inicial de qualquer consulta
                    // for igual a hora inicial da entrada.
                    if (c.HoraInicial == this.HoraInicial)
                        return true;
                    // 2 - A hora inicial da entrada não pode estar entre as horas da consulta
                    else if (int.Parse(this.HoraInicial) > int.Parse(c.HoraInicial) && int.Parse(this.HoraInicial) < int.Parse(c.HoraFinal))
                        return true;
                    // 2 - A hora final da entrada não pode estar entre as horas da consulta
                    else if (int.Parse(this.HoraFinal) > int.Parse(c.HoraInicial) && int.Parse(this.HoraFinal) < int.Parse(c.HoraFinal))
                        return true;
                }
            } //$END_FOREACH

            return false;
        }

        internal bool PossuiAgendamentoFuturo()
        {
            foreach (var c in Agenda.Consultas)
            {
                if (c.CPF == this.CPF)
                {
                    // 1 - Se a data de agora for exatamente igual à data
                    // que já estava marcada (consulta hoje)
                    if (DateOnly.FromDateTime(DateTime.Now)
                        .CompareTo(c.DataConsulta) == 0)
                        return true;

                    // 2 - Se a data de agora for menor que a data que já estava,
                    // significa que ainda não passou e, portanto,
                    // possui agendamento futuro.
                    if (DateOnly.FromDateTime(DateTime.Now)
                        .CompareTo(c.DataConsulta) < 0)
                        return true;

                    // 3 - self-explanatory
                    if (c.DataConsulta == this.DataConsulta)
                        return true;
                }
            }
            return false;
        }
    }
}
