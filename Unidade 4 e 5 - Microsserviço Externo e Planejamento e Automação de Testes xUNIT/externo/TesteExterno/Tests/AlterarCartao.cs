using System.Diagnostics;
using System.Net;

namespace TesteExterno.Tests
{
    public class AlterarCartao : Base
    {
        public AlterarCartao() { }

        [Fact(DisplayName = "Cartão recusado")]
        public async void CT01()
        {
            int idCiclistaExistente = 1;

            var obj = new
            {
                nomeTitular = "Titular teste",
                numero = "4024007153763198",
                validade = "08/2024",
                cvv = "123",
            };


            var response = await GetResponseAsync(obj, $"https://residencia-nebula.ed.dev.br/equipamento-grupo1/cartaoDeCredito/{idCiclistaExistente}", HttpMethod.Put);


            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [Fact(DisplayName = "Ciclista inexistente")]
        public async void CT02()
        {
            int idCiclistaInexistente = 999999999;

            var obj = new
            {
                nomeTitular = "Titular teste",
                numero = "4024007153763198",
                validade = "08/2024",
                cvv = "123",
            };


            var response = await GetResponseAsync(obj, $"https://residencia-nebula.ed.dev.br/equipamento-grupo1/cartaoDeCredito/{idCiclistaInexistente}", HttpMethod.Put);


            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact(DisplayName = "Sucesso")]
        public async void CT03()
        {
            int idCiclista = 1;

            var obj = new
            {
                nomeTitular = "Titular teste",
                numero = "4024007153763190",
                validade = "08/2024",
                cvv = "123",
            };


            var response = await GetResponseAsync(obj, $"https://residencia-nebula.ed.dev.br/equipamento-grupo1/cartaoDeCredito/{idCiclista}", HttpMethod.Put);


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
