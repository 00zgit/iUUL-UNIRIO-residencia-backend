using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q4
{
    internal class Pessoa
    {
        public CertidaoNascimento? certidao;
        public String Nome { get; private set; }
        public CertidaoNascimento? CertidaoNascimento
        {
            get { return certidao; }
            set
            {
                if (certidao == null)
                    certidao = value;

                else
                    throw new InvalidOperationException("Pessoa já possui certidão");
            }
        }

        public Pessoa(String nome)
        {
            this.Nome = nome;
        }
    }
}
