using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Atividade03.Q1
{
    public class ClienteForm
    {
        public string? nome { get; set; }
        public string? cpf { get; set; }
        public string? dt_nascimento { get; set; }
        public string? renda_mensal { get; set; }
        public string? estado_civil { get; set; }
        public string? dependentes { get; set; }
        
        public static List<ClienteForm> ReadData(string strjson)
        {
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var clienteform = JsonSerializer.Deserialize<List<ClienteForm>>(strjson,options);

            return clienteform;
        }

        public static string ReadJsonFile()
        {

            using StreamReader reader = new(@$"{AppContext.BaseDirectory}\clientes.json");
            return reader.ReadToEnd();
        }

        public void ReadInvalidData(Errors err)
        {
            if (!err.IsClienteNomeValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine($"Nome do campo: {nameof(Cliente.Nome)}");
                Console.WriteLine($"Dado: {this.nome}");
                Console.WriteLine("Erro: Nome com menos de 5 caracteres.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.nome = Console.ReadLine();
            }
            if (!err.IsClienteCPFValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine($"Nome do campo: {nameof(Cliente.CPF)}");
                Console.WriteLine($"Dado: {this.cpf}");
                Console.WriteLine("Erro: CPF não existe.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.cpf = Console.ReadLine();
            }
            if (!err.IsClienteDataNascimentoValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine($"Nome do campo: {nameof(Cliente.DataNascimento)}");
                Console.WriteLine($"Dado: {this.dt_nascimento}");
                Console.WriteLine("Erro: Data inválida e/ou idade menor do que 18 anos.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.dt_nascimento = Console.ReadLine();
            }
            if (!err.IsClienteRendaMensalValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine($"Nome do campo: {nameof(Cliente.RendaMensal)}");
                Console.WriteLine($"Dado: {this.renda_mensal}");
                Console.WriteLine("Erro: Renda inválida.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.renda_mensal = Console.ReadLine();
            }
            if (!err.IsClienteEstadoCivilValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine($"Nome do campo: {nameof(Cliente.EstadoCivil)}");
                Console.WriteLine($"Dado: {this.estado_civil}");
                Console.WriteLine("Erro: Estado civil desconhecido.");
                Console.WriteLine(">> Insira um estado civil (Cc/Ss/Vv/Dd) >> ");
                this.estado_civil = Console.ReadLine();
            }
            if (!err.IsClienteQtdDependentesValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine($"Nome do campo: {nameof(Cliente.QtdDependentes)}");
                Console.WriteLine($"Dado: {this.dependentes}");
                Console.WriteLine("Erro: Quantidade de dependentes não pode ser menor que 0 ou maior que 10.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.dependentes = Console.ReadLine();
            }

            return;
        }

        public static void PrintValidCliente(List<Cliente> cList)
        {
            foreach(Cliente c in cList)
            {
                Console.WriteLine();
                Console.WriteLine("---------SUCESSO----------");
                Console.WriteLine("==========Imprimindo cliente===========");
                Console.WriteLine("Nome: " + c.Nome);
                Console.WriteLine("CPF: " + c.CPF);
                Console.WriteLine("Nascimento: " + c.DataNascimento);
                Console.WriteLine("Renda mensal: " + c.RendaMensal);
                Console.WriteLine("Estado civil: " + c.EstadoCivil);
                Console.WriteLine("Quantidade de dependentes: " + c.QtdDependentes);
            }
            
        }
    }
}
