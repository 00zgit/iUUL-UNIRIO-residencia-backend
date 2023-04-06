using Newtonsoft.Json;

namespace TesteExterno
{
    public class Base
    {
        private static HttpClient? _client = null;
        protected static HttpClient Client
        {
            get
            {
                return _client ??= new HttpClient(); // Singleton
            }
        }

        protected Base() { }


        // Método comum às classes de teste para enviar as requsições aos endpoints,
        // que estão fora do nosso domínio.
        protected async Task<HttpResponseMessage> GetResponseAsync(Object obj, string url, HttpMethod method)
        {
            //Arranje
            var request = new HttpRequestMessage(method, url);

            string json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, null, "application/json");
            request.Content = content;

            //Act
            return await Client.SendAsync(request);
        }
    }
}