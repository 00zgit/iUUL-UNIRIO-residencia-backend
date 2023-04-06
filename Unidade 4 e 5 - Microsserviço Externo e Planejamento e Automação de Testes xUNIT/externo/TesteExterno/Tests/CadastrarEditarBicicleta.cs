using System.Net;

namespace TesteExterno.Tests
{
    public class CadastrarEditarBicicleta : Base
    {
        public CadastrarEditarBicicleta() { }


        public static IEnumerable<object[]> Bicicletas_ComDadosObrigatorios_Faltantes()
        {
            yield return new object[]
            {
                new { marca = "teste", modelo = "", ano = "teste", numero = 0, status = "teste" },
                new { marca = "", modelo = "teste", ano = "teste", numero = 1, status = "teste" },
                new { marca = "", modelo = "", ano = "teste", numero = 2, status = "teste" }
            };
        }

        [Theory(DisplayName = "Cadastro dados obrigatórios nulos")]
        [MemberData(nameof(Bicicletas_ComDadosObrigatorios_Faltantes))]
        public async void CT01(params object[] obj)
        {
            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/equipamento-grupo1/bicicleta", HttpMethod.Post);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }


        [Fact(DisplayName = "Cadastro sucesso")]
        public async void CT02()
        {
            var obj = new
            {
                marca = "sucesso",
                modelo = "sucesso",
                ano = "sucesso",
                numero = 0,
                status = "sucesso"
            };


            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/equipamento-grupo1/bicicleta", HttpMethod.Post);


            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }


        [Fact(DisplayName = "Editar bicicleta inexistente")]
        public async void CT04()
        {
            int idBicicletaInexistente = 999999;

            var obj = new
            {
                marca = "erro",
                modelo = "erro",
                ano = "erro",
                numero = 0,
                status = "erro"
            };


            var response = await GetResponseAsync(obj, $"https://residencia-nebula.ed.dev.br/equipamento-grupo1/bicicleta/{idBicicletaInexistente}", HttpMethod.Put);


            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


    }
}
