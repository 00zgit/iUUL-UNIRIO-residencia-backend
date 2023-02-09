using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q4
{
    internal class CertidaoNascimento
    {
        public DateOnly DataEmissao { get; private set; }
        public Pessoa Pessoa { get; private set; }

        public CertidaoNascimento(Pessoa pessoa,DateOnly emissao)
        {
            if (pessoa == null)
                throw new ArgumentException("Pessoa não pode ser nula.");


            this.DataEmissao = emissao;
            this.Pessoa = pessoa; //Associa certidão à pessoa

            //Associa pessoa à essa certidão !! (Amarrou)
            pessoa.CertidaoNascimento = this;
        }
    }
}
