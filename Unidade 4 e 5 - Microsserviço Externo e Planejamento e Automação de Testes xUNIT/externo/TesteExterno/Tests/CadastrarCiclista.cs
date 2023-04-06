using System.Diagnostics;
using System.Net;

namespace TesteExterno.Tests
{
    public class CadastrarCiclista : Base
    {
        public CadastrarCiclista() { }

        [Fact(DisplayName = "Email Inválido")]
        public async void CT01()
        {
            //Arranje
            object obj = new
            {
                status = "string",
                nome = "string",
                nascimento = "2023-03-27",
                cpf = "62930999071",
                nacionalidade = "brasileiro",
                email = "xxxx2.com",
                senha = "123456",
                confirmacaoSenha = "123456",
                urlFotoDocumento = "string",
                meioDePagamento = new
                {
                    nomeTitular = "Titular Teste",
                    numero = "4024007153763191",
                    validade = "08/2024",
                    cvv = "123"
                },
                passaporte = new
                {
                    numero = "string",
                    validade = "2023-03-27",
                    pais = "BR"
                }
            };

            //Act
            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/aluguel-grupo1/ciclista", HttpMethod.Post);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }



        [Fact(DisplayName = "Email válido não cadastrado")]
        public async void CT02()
        {
            var myHash = DateTime.Now.Millisecond;
            var _novoEmail = myHash * myHash;

            object obj = new
            {
                status = "string",
                nome = "string",
                nascimento = "2023-03-27",
                cpf = "62930999071",
                nacionalidade = "brasileiro",
                email = $"xxxx{_novoEmail}@email.com",
                senha = "123456",
                confirmacaoSenha = "123456",
                urlFotoDocumento = "string",
                meioDePagamento = new
                {
                    nomeTitular = "Titular Teste",
                    numero = "4024007153763191",
                    validade = "08/2024",
                    cvv = "123"
                },
                passaporte = new
                {
                    numero = "string",
                    validade = "2023-03-27",
                    pais = "BR"
                }
            };


            //Act
            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/aluguel-grupo1/ciclista", HttpMethod.Post);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }



        [Fact(DisplayName = "CPF inválido")]
        public async void CT03()
        {
            object obj = new
            {
                status = "string",
                nome = "string",
                nascimento = "2023-03-27",
                cpf = "11111111111",
                nacionalidade = "brasileiro",
                email = "xxxx2@email.com",
                senha = "123456",
                confirmacaoSenha = "123456",
                urlFotoDocumento = "string",
                meioDePagamento = new
                {
                    nomeTitular = "Titular Teste",
                    numero = "4024007153763191",
                    validade = "08/2024",
                    cvv = "123"
                },
                passaporte = new
                {
                    numero = "string",
                    validade = "2023-03-27",
                    pais = "BR"
                }
            };


            //Act
            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/aluguel-grupo1/ciclista", HttpMethod.Post);

            //Assert
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }



        [Fact(DisplayName = "Cartão de crédito inválido")]
        public async void CT06()
        {
            object obj = new
            {
                status = "string",
                nome = "string",
                nascimento = "2023-03-27",
                cpf = "62930999071",
                nacionalidade = "brasileiro",
                email = "xxxx2@email.com",
                senha = "123456",
                confirmacaoSenha = "123456",
                urlFotoDocumento = "string",
                meioDePagamento = new
                {
                    nomeTitular = "Titular Teste",
                    numero = "4024007153763192",
                    validade = "08/2024",
                    cvv = "123"
                },
                passaporte = new
                {
                    numero = "string",
                    validade = "2023-03-27",
                    pais = "BR"
                }
            };


            //Act
            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/aluguel-grupo1/ciclista", HttpMethod.Post);

            //Assert
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }



        [Fact(DisplayName = "Email já cadastrado no sistema")]
        public async void CT08()
        {
            object obj = new
            {
                status = "string",
                nome = "string",
                nascimento = "2023-03-27",
                cpf = "62930999071",
                nacionalidade = "brasileiro",
                email = "xxxx2@email.com",
                senha = "123456",
                confirmacaoSenha = "123456",
                urlFotoDocumento = "string",
                meioDePagamento = new
                {
                    nomeTitular = "Titular Teste",
                    numero = "4024007153763191",
                    validade = "08/2024",
                    cvv = "123"
                },
                passaporte = new
                {
                    numero = "string",
                    validade = "2023-03-27",
                    pais = "BR"
                }
            };

            //Act
            var response = await GetResponseAsync(obj, "https://residencia-nebula.ed.dev.br/aluguel-grupo1/ciclista", HttpMethod.Post);

            //Assert
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }
    }
}