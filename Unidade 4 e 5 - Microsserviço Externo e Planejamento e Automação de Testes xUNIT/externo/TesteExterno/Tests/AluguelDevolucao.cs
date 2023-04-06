using System.Net;

namespace TesteExterno.Tests
{
    public class AluguelDevolucao : Base
    {
        public AluguelDevolucao() { }

        // Arranje via Postman:

        /*
         * Bicicleta
         * 
         * {
                "id": 80,
                "marca": "Teste Devolucao Bicicleta",
                "modelo": "Teste Devolucao Bicicleta",
                "anoFabricacao": 0,
                "numero": 1467351444,
                "status": "EM_USO"
            }
         * 
         * 
         * Tranca
         * 
         * {
                "id": 43,
                "bicicletaId": null,        // OBS: postman retornou null mesmo com  o id 80
                "numero": 19,
                "localizacao": "Teste Devolucao Bicicleta",
                "anoFabricacao": 2023,
                "modelo": "Teste Devolucao Bicicleta",
                "status": "LIVRE"
            }
         * 
         * 
         * Ciclista
         * 
         * {
         *    "id": "14",
              "status": "string",
              "nome": "string",
              "nascimento": "2023-03-27",
              "cpf": "62930999071",
              "nacionalidade": "brasileiro",
              "email": "user123@.com",
              "senha": "123456",
              "confirmacaoSenha":"123456",
              "urlFotoDocumento": "string",
              "meioDePagamento":{
                  "nomeTitular":"Titular Teste",
                  "numero":"4024007153763191",
                  "validade":"08/2024",
                  "cvv":"123"
              },
              "passaporte": {
                "numero": "string",
                "validade": "2023-03-27",
                "pais": "ZG"
              }
            }
         */

        [Fact(DisplayName = "Aluguel com sucesso")]
        public async void CT01()
        {
            var obj = new
            {
                trancaInicio = 43,
                ciclista = 14
            };

            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/aluguel-grupo1/aluguel", HttpMethod.Post);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Devolução com sucesso")]
        public async void CT02()
        {
            var obj = new
            {
                idTranca = 43,
                idBicicleta = 80
            };

            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/aluguel-grupo1/devolucao", HttpMethod.Post);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
