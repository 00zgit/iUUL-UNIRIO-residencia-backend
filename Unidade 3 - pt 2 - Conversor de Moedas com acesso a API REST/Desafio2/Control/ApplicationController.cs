using CurrencyExchangeAPI_RESTful.Model;
using CurrencyExchangeAPI_RESTful.Validators;
using CurrencyExchangeAPI_RESTful.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI_RESTful.Control
{
    internal class ApplicationController
    {
        public static async void Start()
        {
            // Open and configure client
            Console.Write("\nOpenning Http client...");
            HttpClientController client = new HttpClientController();
            Console.Write("\nOK");
            Console.Write("\nConfiguring Http client...");
            client.ConfigureHttpClient();
            Console.Write("\nOK");

            // Get list of available currencies worldwide, generate objects and save symbols list
            Console.Write("\nGetting list of currency codes...");
            var symbols = await client.GetSymbolsAsync();
            Currency c = new(symbols);
            Console.Write("\nOK");
            
            // Get user inputs, do conversion and generate object
            Console.Write("\nOpenning user form...");
            FormValidator fv = new();
            var exchange = UI.Form(fv,c);
            if (exchange == null) return; // Terminate program
            Console.Write("\nForm complete!");
            Console.Write("\nStarting conversion...");
            var conversion = await client.ConvertAsync(exchange);
            Console.Write("\nOK");

            // Finally, print stuff in a human-readable-format
            Console.Write("\n\nYour conversion:");
            UI.Print(exchange,conversion);
        }
    }
}
