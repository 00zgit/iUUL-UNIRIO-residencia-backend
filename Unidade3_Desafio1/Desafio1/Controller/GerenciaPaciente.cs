using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Form;
using Consultorio.Model;
using Consultorio.View;

namespace Consultorio.Controller
{
    internal class GerenciaPaciente
    {
        public List<Paciente> Pacientes { get; private set; }

        public GerenciaPaciente()
        {
            Pacientes = new List<Paciente>();
        }

        internal bool ExistePaciente(string? entrada)
        {
            if(entrada == null) return false;

            foreach(Paciente paciente in this.Pacientes)
            {
                if(paciente.CPF == entrada)
                    return true;
            }

            return false;
        }

        internal void RemovePaciente(string cpf)
        {
            var paciente = this.RetornaPaciente(cpf);

            if (paciente == null) throw new Exception();

            // Pacientes com consulta futura não podem ser removidos
            if (paciente.ExisteAgendamento())
                throw new Exception();

            this.Pacientes.Remove(paciente);
        }

        

        internal Paciente? RetornaPaciente(string cpf)
        {
            foreach (Paciente paciente in this.Pacientes) // Buscar o CPF.
            {
                //Verifica se existe um Paciente com este CPF
                if (paciente.CPF == cpf)
                {
                    return paciente;
                }
            }
            return null;
        }
    }
}
