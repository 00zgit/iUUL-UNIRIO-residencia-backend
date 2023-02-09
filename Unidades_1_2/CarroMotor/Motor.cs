using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q5
{
    public class Motor
    {
        public String cilindrada;
        public String Cilindrada
        {
            get { return cilindrada;}
            set
            {
                if(value != "1000" ||
                   value != "1600" ||
                   value != "2000")
                    throw new ArgumentException("Cilindrada não existe");
                cilindrada = value;
            }
        }
        private Carro? carro;
        public Carro? Carro
        {
            get { return carro; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Carro precisa estar associado a um motor.");

                if (value.Motor != this)
                    throw new ArgumentException("Carro não pode possuir outro motor");

                carro = value;
            }
        }

        public Motor(string cl)
        {
            this.Cilindrada = cl;
        }
    }
}