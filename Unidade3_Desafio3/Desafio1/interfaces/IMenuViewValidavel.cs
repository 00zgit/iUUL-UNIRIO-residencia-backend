using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Validators
{
    public interface IMenuViewValidavel
    {
        public abstract bool ValidaEscolha(string? entrada, int tipoMenu);
    }
}
