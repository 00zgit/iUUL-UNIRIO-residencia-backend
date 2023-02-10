using Consultorio.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsultorioOdontoDB.Model.Form
{
    public class PacienteForm
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }

        public PacienteForm() { }

    }
}
