using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01
{
    internal class Cliente
    {
        public string nome;
        public long cpf;
        public DateTime dataNascimento;
        public float rendaMensal;
        public char estadoCivil;
        public int qtdDependentes;

        public Cliente(string nome, string cpf, string dataNascimento, string rendaMensal, string estadoCivil, string qtdDependentes)
        {
            String nome_validado = ValidaNome(nome);
            this.nome = nome_validado;

            long cpf_validado = ValidaCPF(cpf);
            this.cpf = cpf_validado;

            DateTime dataNascimento_validado = ValidaNascimento(dataNascimento);
            this.dataNascimento = dataNascimento_validado;

            float rendaMensal_validado = ValidaRendaMensal(rendaMensal);
            this.rendaMensal = rendaMensal_validado;

            char estadoCivil_validado = ValidaEstadoCivil(estadoCivil);
            this.estadoCivil = estadoCivil_validado;

            int qtdDependentes_validado = ValidaQtdDependentes(qtdDependentes);
            this.qtdDependentes = qtdDependentes_validado;
        }

        private String ValidaNome(string nome)
        {
            while (nome.Length < 5)
            {
                Console.WriteLine("Favor, inserir nome de pelo menos 5 caracteres: ");
                nome = Console.ReadLine();
            }
            return nome;
        }
        private long ValidaCPF(string cpf)
        {
            while (cpf.Length != 11)
            {
                Console.WriteLine("Favor, inserir CPF de 11 dígitos: ");
                cpf = Console.ReadLine();
            }
            return long.Parse(cpf);
        }

        private DateTime ValidaNascimento(String dt)
        {
            String format = "dd/MM/yyyy";
            DateTime date = DateTime.ParseExact(dt, format, System.Globalization.CultureInfo.InvariantCulture);

            DateTime now = DateTime.Now;

            int year = date.Year;
            int nowYear = now.Year;

            while ((nowYear - year) < 18)
            {
                Console.WriteLine("A data deve dar pelo menos 18 anos: ");
                dt = Console.ReadLine();

                date = DateTime.ParseExact(dt, format, System.Globalization.CultureInfo.InvariantCulture);
                year = date.Year;
            }

            return date;
        }

        private float ValidaRendaMensal(String renda)
        {
            float myFloat = float.Parse(renda);
            while (true)
            {
                if (!renda.Contains(','))
                {
                    Console.WriteLine("O valor deverá ter vírgula na casa decimal: ");
                    renda = Console.ReadLine();
                }
                else
                {
                    return float.Parse(renda.Remove(renda.IndexOf(',')+3));
                }
            }
        }

        enum EC
        {
            C,
            S,
            V,
            D
        }

        private char ValidaEstadoCivil(String estadoCivil)
        {

            while (true)
            {
                foreach (var ec in Enum.GetNames(typeof(EC)))
                {
                    if (estadoCivil.ToUpper() == ec.ToString())
                    {
                        return char.Parse(estadoCivil.ToUpper());
                    }
                }
                Console.WriteLine("Favor inserir um estado civil válido (C c / S s / V v / D d): ");
                estadoCivil = Console.ReadLine();
            }
        }

        private int ValidaQtdDependentes(String qtd)
        {
            int dependentes = int.Parse(qtd);
            while(dependentes < 0 || dependentes > 10)
            {
                Console.WriteLine("Quantidade válida de dependentes entre 0 e 10: ");
                qtd = Console.ReadLine();
            }
            return dependentes = int.Parse(qtd);
        }

        public void ImprimeCliente(Cliente c)
        {
            Console.WriteLine();
            Console.WriteLine("==========Imprimindo cliente===========");
            Console.WriteLine("Nome: "+c.nome);
            Console.WriteLine("CPF: " + c.cpf);
            Console.WriteLine("Nascimento: "+c.dataNascimento);
            Console.WriteLine("Renda mensal: " + c.rendaMensal);
            Console.WriteLine("Estado civil: " + c.estadoCivil);
            Console.WriteLine("Quantidade de dependentes: " + c.qtdDependentes);
        }
    }
}
