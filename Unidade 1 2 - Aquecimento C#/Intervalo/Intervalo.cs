using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01
{
    internal class Intervalo
    {
        public DateTime initTime { get; }
        public DateTime endTime { get; }

        public Intervalo(DateTime init, DateTime end)
        {
            if(init.CompareTo(end) > 0)
            {
                throw new ArgumentException("Data/Hora começo maior que Data/Hora final");
            }
            else
            {
                this.initTime = init;
                this.endTime = end;
            }
        }

        public bool TemIntersecao(Intervalo i)
        {
            if (this.initTime.Ticks <= i.endTime.Ticks && this.initTime.Ticks >= i.initTime.Ticks)
            {
                return true;
            }
            if (this.endTime.Ticks >= i.initTime.Ticks && this.endTime.Ticks <= i.endTime.Ticks)
            {
                return true;
            }
            return false;
        }
        
        public bool ComparaIntervalo(Intervalo i)
        {
            if(initTime.Equals(i.initTime) && endTime.Equals(i.endTime))
            {
                return true;
            }
            return false;
        }

        public TimeSpan DuracaoIntervalo(Intervalo i)
        {
            TimeSpan interval = i.endTime - i.initTime;
            return interval;
        }
    }
}
