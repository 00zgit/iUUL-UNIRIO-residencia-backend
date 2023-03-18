using System.Text.Json;

namespace scb_externo.services
{
    public class AluguelAPI
    {
        public AluguelAPI() { }

        public async Task<JsonDocument?> RecuperaCartaoPorID(string url)
        {
            JsonDocument? info = null;

            using (var client = new HttpClient())
            {
                try
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                    };

                    var response = await client.SendAsync(request).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    info = JsonDocument.Parse(responseBody);
                }
                catch (Exception e)
                { }

                return info;
            }
        }

        public async Task<JsonDocument?> RecuperaCiclistaPorID(string url)
        {
            JsonDocument? info = null;

            using (var client = new HttpClient())
            {
                try
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                    };

                    var response = await client.SendAsync(request).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    info = JsonDocument.Parse(responseBody);
                }
                catch (Exception e)
                { }

                return info;
            }
        }
    }
}
