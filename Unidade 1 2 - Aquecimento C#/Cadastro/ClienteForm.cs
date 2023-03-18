using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade03.Q1
{
    public class ClienteForm
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string RendaMensal { get; set; }
        public string EstadoCivil { get; set; }
        public string QtdDependentes { get; set; }
        
        public ClienteForm()
        {
        }
        

        public ClienteForm ReadData()
        {
            Console.WriteLine("Insira um nome: ");
            string Nome = Console.ReadLine();
            this.Nome = Nome;
            Console.WriteLine("Insira um cpf: ");
            string CPF = Console.ReadLine();
            this.CPF = CPF;
            Console.WriteLine("Insira uma data de nascimento (dd/mm/yyyy): ");
            string DataNascimento = Console.ReadLine();
            this.DataNascimento = DataNascimento;
            Console.WriteLine("Insira uma renda mensal: ");
            string RendaMensal = Console.ReadLine();
            this.RendaMensal = RendaMensal;
            Console.WriteLine("Insira um estado civil (C c / S s / V v / D d): ");
            string EstadoCivil = Console.ReadLine();
            this.EstadoCivil = EstadoCivil;
            Console.WriteLine("Insira uma quantidade de dependentes: ");
            string QtdDependentes = Console.ReadLine();
            this.QtdDependentes = QtdDependentes;

            return this;
        }

        public ClienteForm ReadInvalidData(Errors err)
        {
            if (!err.IsClienteNomeValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: Nome");
                Console.WriteLine($"Dado: {this.Nome}");
                Console.WriteLine("Erro: Nome com menos de 5 caracteres.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.Nome = Console.ReadLine();
                

            }
            if (!err.IsClienteCPFValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: CPF");
                Console.WriteLine($"Dado: {this.CPF}");
                Console.WriteLine("Erro: CPF não existe.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.CPF = Console.ReadLine();
            }
            if (!err.IsClienteDataNascimentoValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: DataNascimento");
                Console.WriteLine($"Dado: {this.DataNascimento}");
                Console.WriteLine("Erro: Data inválida e/ou idade menor do que 18 anos.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.DataNascimento = Console.ReadLine();
                
            }
            if (!err.IsClienteRendaMensalValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: RendaMensal");
                Console.WriteLine($"Dado: {this.RendaMensal}");
                Console.WriteLine("Erro: Renda inválida.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.RendaMensal = Console.ReadLine();
                
            }
            if (!err.IsClienteEstadoCivilValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: EstadoCivil");
                Console.WriteLine($"Dado: {this.EstadoCivil}");
                Console.WriteLine("Erro: Estado civil desconhecido.");
                Console.WriteLine(">> Insira um estado civil (Cc/Ss/Vv/Dd) >> ");
                this.EstadoCivil = Console.ReadLine();
                
            }
            if (!err.IsClienteQtdDependentesValid)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: QtdDependentes");
                Console.WriteLine($"Dado: {this.QtdDependentes}");
                Console.WriteLine("Erro: Quantidade de dependentes não pode ser menor que 0 ou maior que 10.");
                Console.WriteLine(">> Insira um novo valor >> ");
                this.QtdDependentes = Console.ReadLine();
                
            }

            return this;
        }

        public void PrintValidCliente(Cliente c)
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
