using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q5
{
    public class Carro
    {
        public String Placa { get; private set; }
        public String Modelo { get; private set; }
        public Motor motor;
        public Motor Motor
        {
            get { return motor; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("Carro não pode ficar sem motor");
                if (this.motor != value && value.Carro != this)
                    throw new ArgumentException("Carro não pode trocar de motor.");
                motor = value;
            }
        }

        public Carro(string placa, string modelo, Motor motor)
        {
            this.Placa = placa;
            this.Modelo = modelo;


            this.Motor = motor; //verifica primeiro se o carro já possui um motor
            motor.Carro = this; //atribui esse carro a um motor
        }
    }
}
