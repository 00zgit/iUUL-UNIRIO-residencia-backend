using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Validators
{
    public interface IPacienteValidavel
    {
        public abstract bool IsNome(string entrada);
        public abstract bool IsDataNascimento(string entrada);
        public abstract bool ValidaCPF(string entrada);
        public abstract bool IsCPF(string cpf);
        public abstract bool ValidaConversaoCPF(string entrada);
    }
}