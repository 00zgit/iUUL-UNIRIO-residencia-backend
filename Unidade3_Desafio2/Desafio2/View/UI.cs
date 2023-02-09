using CurrencyExchangeAPI_RESTful.Exceptions;
using CurrencyExchangeAPI_RESTful.Model;
using CurrencyExchangeAPI_RESTful.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI_RESTful.View
{
    internal static class UI
    {
        public static Exchange? Form(FormValidator formValidator, Currency c)
        {
            UI.PrintCurrencies(c);

            
            FROM:
            Console.Write("\nFrom: ");
            var from = Console.ReadLine();
            try
            {
                formValidator.TryValidateCurrency(from,c);
            }
            catch (ExitApplicationCodeException) { return null; }
            catch(MyCurrencyExchangeAPIException){ goto FROM; }


            TO:
            Console.Write("\nTo: ");
            var to = Console.ReadLine();
            try
            {
                formValidator.TryValidateCurrency(to,c);
            }
            catch (MyCurrencyExchangeAPIException) { goto TO; }
            formValidator.OriginChoice = null;

            
            AMOUNT:
            Console.Write("\nAmount: ");
            var amount = Console.ReadLine();
            try
            {
                FormValidator.TryValidateAmount(amount);
            }
            catch (MyCurrencyExchangeAPIException) { goto AMOUNT; }


            return new Exchange(from,to,float.Parse(String.Format("{0:0.0}", amount)));
        }




        public static void PrintCurrencies(Currency c)
        {
            int count = 1;
            foreach (var s in c.GetSymbols())
            {
                Console.Write($"[{s.Code}]\t");
                if (count % 4 == 0) Console.WriteLine();
                ++count;
            }
        }
        internal static void Print(Exchange ex,Conversion cv)
        {
            Console.WriteLine($"----{ex.Origin} to {ex.Destiny}----");
            Console.WriteLine($"\t\t{ex.Amount} = {cv.Result}\t\t");
        }
    }
}
