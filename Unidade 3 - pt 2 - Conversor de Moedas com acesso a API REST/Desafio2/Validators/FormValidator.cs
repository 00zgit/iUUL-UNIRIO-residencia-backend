using CurrencyExchangeAPI_RESTful.Model;
using CurrencyExchangeAPI_RESTful.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI_RESTful.Validators
{
    internal class FormValidator
    {
        public string? OriginChoice { get; set; }
        
        internal void TryValidateCurrency(string input,Currency c)
        {
            if (input == "") throw new ExitApplicationCodeException();
            if(input.Length != 3) throw new ArgumentLenghtException("[ERROR] Invalid currency code lenght.");
            if(!c.IsValidSymbol(input)) throw new CurrencyNotValidException("[ERROR] Currency code unexistent.");
            if (OriginChoice != null)
                if (OriginChoice == input) throw new SameCurrencyException("[ERROR] Currencies cannot be of the same type for conversion.");
            else OriginChoice = input;
        }

        internal static void TryValidateAmount(string amount)
        {
            if (!float.TryParse(amount, out float value)) throw new InvalidAmountException();
            if (value <= 0) throw new InsufficientAmountException();
        }
    }
}
