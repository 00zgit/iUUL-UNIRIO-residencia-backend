using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using CurrencyExchangeAPI_RESTful.Model;
using System.Net.Http.Json;
using System.Text.Json;
using static System.IO.Stream;
using System.IO;

namespace CurrencyExchangeAPI_RESTful.Control
{
    internal class HttpClientController
    {
        public HttpClient Client { get; set; }

        public HttpClientController()
        {
            this.Client = new HttpClient();
        }

        public void ConfigureHttpClient()
        {
            this.Client.DefaultRequestHeaders.Accept.Clear();
            this.Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal async Task<List<Symbol>> GetSymbolsAsync()
        {
            using Stream stream = 
                await this.Client.GetStreamAsync("https://api.exchangerate.host/symbols?");

            var symbols = 
                await JsonSerializer.DeserializeAsync<List<Symbol>>(stream);

            return symbols ?? new();
        }

        internal async Task<Conversion> ConvertAsync(Exchange exchange)
        {
            await using Stream stream = 
                await this.Client.GetStreamAsync("https://api.exchangerate.host/convert?" +
                "from="     + exchange.Origin   +
                "&to="      + exchange.Destiny  +
                "&amount="  + exchange.Amount);
            var conversion = 
                await JsonSerializer.DeserializeAsync<Conversion>(stream);

            return conversion;
        }
    }
}
