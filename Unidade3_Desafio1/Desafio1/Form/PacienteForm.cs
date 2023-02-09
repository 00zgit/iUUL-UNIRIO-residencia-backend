using Consultorio.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Consultorio.Form
{
    public class PacienteForm : IPacienteValidavel
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? DataNascimento { get; set; }

        public PacienteForm() { }

        /**********************/
        /* VALIDAÇÕES DE NOME */
        /**********************/
        public bool IsNome(string? entrada)
        {
            if (entrada == null) return false;
            return entrada.Length >= 5;
        }

        /************************************/
        /* VALIDAÇÕES DE DATA DE NASCIMENTO */
        /************************************/
        public bool IsDataNascimento(string? entrada)
        {
            if (entrada == null) return false;

            string format = "dd/MM/yyyy";
            DateTime DataFormatada;
            int AnoAtual, AnoNascimento;

            try
            {
                DataFormatada = DateTime.ParseExact(entrada, format, CultureInfo.InvariantCulture);

            }
            catch (Exception) { return false; }

            DateTime now = DateTime.Now;
            AnoAtual = now.Year;
            AnoNascimento = DataFormatada.Year;

            if (AnoAtual - AnoNascimento <= 12) return false;

            return true;
        }

        /*********************/
        /* VALIDAÇÕES DE CPF */
        /*********************/
        public bool ValidaCPF(string? entrada)
        {
            if (entrada == null) return false;
            bool cpfValido = this.IsCPF(entrada);
            bool conversaoValida = this.ValidaConversaoCPF(entrada);
            if (!cpfValido || !conversaoValida)
                return false;
            return true;
        }

        // Fonte: https://macoratti.net/11/09/c_val1.htm
        public bool IsCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }
        public bool ValidaConversaoCPF(string entrada)
        {
            try
            {
                long.Parse(entrada);
            }
            catch (Exception) { return false; }
            return true;
        }
    }
}
