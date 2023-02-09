using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI_RESTful.Model
{
    internal class Currency
    {
        private IList<Symbol> symbols;
        public IList<Symbol> Symbols { get { return new ReadOnlyCollection<Symbol>(symbols); } }

        public Currency(List<Symbol> s)
        {
            symbols = s;
        }

        public IList<Symbol> GetSymbols()
        {
            return Symbols;
        }

        public bool IsValidSymbol(string input)
        {
            foreach (var c in Symbols)
            {
                if (c.Code.Equals(input)) return true;
            }
            return false;
        }
    }
}
