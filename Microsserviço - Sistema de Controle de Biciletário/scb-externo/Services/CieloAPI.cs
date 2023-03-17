using Newtonsoft.Json;
using scb_externo.Models;

namespace scb_externo.services
{
    public class CieloAPI
    {
        public CieloAPI() { }
        public async Task<HttpResponseMessage> ProcessaValidacao(NovoCartaoDeCredito novoCartao)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://apisandbox.cieloecommerce.cielo.com.br/1/sales");

            request.Headers.Add("MerchantId", "b180a163-3cfb-40af-a24c-b2bd5038373a");
            request.Headers.Add("MerchantKey", "ATQFHQWHNZDOOLEWISWHRAQVHXBXTINDJNZPSXQD");

            // as seguintes propriedades são obrigatórias.
            object obj = new
            {
                MerchantOrderId = "2014111903",
                Customer = new { Name = "Teste" },
                Payment = new
                {
                    Type = "CreditCard",
                    Amount = "15700",
                    Provider = "Cielo",
                    ReturnUrl = "https://www.google.com.br",
                    Installments = "1",
                    Authenticate = "true",
                    CreditCard = new
                    {
                        CardNumber = novoCartao.Numero,
                        Holder = novoCartao.NomeTitular,
                        ExpirationDate = novoCartao.Validade,
                        SecurityCode = novoCartao.Cvv,
                        Brand = "Visa"
                    }
                }
            };

            string json = JsonConvert.SerializeObject(obj);

            var content = new StringContent(json, null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);

            return response;
        }


        //... ProcessaCobranca()
    }
}
