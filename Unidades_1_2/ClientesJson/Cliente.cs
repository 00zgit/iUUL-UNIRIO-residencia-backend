using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade03.Q1
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public long CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public float RendaMensal { get; private set; }
        public char EstadoCivil { get; private set; }
        public int QtdDependentes { get; private set; }

        public Cliente(ClienteForm cf)
        {
            if (cf == null)
                throw new ArgumentNullException("ClienteForm não pode ser nulo");
            this.Nome = cf.nome;
            this.CPF = long.Parse(cf.cpf);
            this.DataNascimento = DateTime.Parse(cf.dt_nascimento);
            this.RendaMensal = float.Parse(cf.renda_mensal);
            this.EstadoCivil = char.Parse(cf.estado_civil);
            this.QtdDependentes = int.Parse(cf.dependentes);
        }
    }
}
