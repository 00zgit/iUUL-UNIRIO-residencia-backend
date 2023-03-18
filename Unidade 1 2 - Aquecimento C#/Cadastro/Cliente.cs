using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    internal class Cliente
    {
        protected internal string Nome { get; set; }
        protected internal long CPF { get; set; }
        protected internal DateTime DataNascimento { get; set; }
        protected internal float RendaMensal { get; set; }
        protected internal char EstadoCivil { get; set; }
        protected internal int QtdDependentes { get; set; }

        public Cliente(ClienteForm cf)
        {
            Nome = cf.Nome;
            CPF = long.Parse(cf.CPF);
            DataNascimento = DateTime.Parse(cf.DataNascimento);
            RendaMensal = float.Parse(cf.RendaMensal);
            EstadoCivil = char.Parse(cf.EstadoCivil);
            QtdDependentes = int.Parse(cf.QtdDependentes);
        }
    }
}
