using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExchangeAPI_RESTful.Control;

namespace CurrencyExchangeAPI_RESTful.Model
{
    internal class Exchange
    {
        public string Origin { get; private set; }
        public string Destiny { get; private set; }
        public float Amount { get; private set; }

        public Exchange(string origin, string destiny, float amount)
        {
            Origin = origin;
            Destiny = destiny;
            Amount = amount;
        }

        public Exchange() { }
    }
}
