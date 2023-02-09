using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioDB
{
    public class Paciente
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }

        private Consulta? consulta;
        public Consulta Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }

        public Paciente(string nome, string cpf, DateTime data)
        {
            consulta = null;
            Nome = nome;
            CPF = cpf;
            DataNascimento = data;
        }


        internal bool ExisteAgendamento()
        {
            return (this.Consulta != null) &&
                        (DateOnly.FromDateTime(DateTime.Now).CompareTo(
                            this.Consulta.DataConsulta) < 0);
        }

        public void MarcaConsulta(Consulta c, Agenda a)
        {
            if (consulta == null || c == null) // Para excluir a consulta, o c será null.
            {
                // se for a marcação de uma consulta, verificar sobreposição
                if (c != null)
                    if (c.PossuiAgendamentoSobreposto(a))
                        throw new Exception();

                consulta = c;
            }


            // Não pode existir agendamentos futuros
            else if (c.PossuiAgendamentoFuturo(a))
                throw new Exception();


            // Não pode existir agendamentos sobrepostos
            else if (c.PossuiAgendamentoSobreposto(a))
                throw new Exception();


            else
                this.Consulta = consulta;
        }
    }
}
