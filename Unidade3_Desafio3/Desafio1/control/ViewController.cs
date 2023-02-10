using Consultorio.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontoDB.control
{
    public static class ViewController
    {
        public static void AbrirCadastroPaciente()
        {
            ViewCadastro vc = new();
            vc.CadastroPaciente();
        }
    }
}
