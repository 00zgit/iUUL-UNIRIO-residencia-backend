using Atividade02.Q1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade03
{
    internal class ValidaClienteForm
    {
        private enum EC{C,S,V,D}
        
        public bool IsValid(ClienteForm cf,Errors err)
        {

            //Valida Nome
            if (!IsNome(cf.Nome))
            {
                err.IsClienteNomeValid = false;
                return false;
            }
            else err.IsClienteNomeValid = true;

            //Valida CPF
            if (!IsCpf(cf.CPF))
            {
                err.IsClienteCPFValid = false;
                return false;
            }
            else err.IsClienteCPFValid = true;

            //Valida DataNascimento
            if (!IsDataNascimento(cf.DataNascimento))
            {
                err.IsClienteDataNascimentoValid = false;
                return false;
            }
            else err.IsClienteDataNascimentoValid = true;

            //Valida RendaMensal
            if (!IsRendaMensal(cf.RendaMensal))
            {
                err.IsClienteRendaMensalValid = false;
                return false;
            }
            else err.IsClienteRendaMensalValid = true;

            //Valida EstadoCivil
            if (!IsEstadoCivil(cf.EstadoCivil))
            {
                err.IsClienteEstadoCivilValid = false;
                return false;
            }
            else err.IsClienteEstadoCivilValid = true;

            //Valida QtdDependentes
            if (!IsQtdDependentes(cf.QtdDependentes))
            {
                err.IsClienteQtdDependentesValid = false;
                return false;
            }
            else err.IsClienteQtdDependentesValid = true;

            return true;
        }

        private static bool IsNome(string valor)
        {
            return valor.Length >= 5;
        }

        // Código: https://macoratti.net/11/09/c_val1.htm
        private static bool IsCpf(string cpf)
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
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private static bool IsDataNascimento(string valor)
        {
            String format = "dd/MM/yyyy";
            DateTime DataFormatada;
            int AnoAtual, AnoNascimento;
            try
            {
                DataFormatada = DateTime.ParseExact(valor, format, System.Globalization.CultureInfo.InvariantCulture);
                
            }
            catch (Exception) { return false; }

            DateTime now = DateTime.Now;
            AnoAtual = now.Year;
            AnoNascimento = DataFormatada.Year;

            if ((AnoAtual - AnoNascimento) <= 17) return false;

            return true;
        }

        private static bool IsRendaMensal(string valor)
        {
            //...

            return true;
        }

        private static bool IsEstadoCivil(string value)
        {
            if (value.Length == 1)
                foreach (var ec in Enum.GetNames(typeof(EC)))
                    if (value.ToUpper() == ec.ToString())
                        return true;
            return false;
        }

        private static bool IsQtdDependentes(string qtd)
        {
            int dependentes;
            try
            {
                dependentes = int.Parse(qtd);
            }catch(Exception) { return false; }

            if (dependentes >= 0 && dependentes <= 10) return true;

            return false;
        }
    }
}