using Atividade03.Q1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade03.Q1
{
    public class ValidaClienteForm
    {
        private enum EC{C,S,V,D}
        
        public static bool IsValid(ClienteForm? cf,Errors err)
        {
            Errors clienteERR = new();

            //Valida Nome
            if (!IsNome(cf.nome))
            {
                clienteERR.dados.Add("nome",cf.nome);
                err.IsClienteNomeValid = false;
                return false;
            }
            else err.IsClienteNomeValid = true;

            //Valida CPF
            if (!IsCpf(cf.cpf))
            {
                clienteERR.dados.Add("cpf",cf.cpf);
                err.IsClienteCPFValid = false;
                return false;
            }
            else err.IsClienteCPFValid = true;

            //Valida DataNascimento
            if (!IsDataNascimento(cf.dt_nascimento))
            {
                clienteERR.dados.Add("dt_nascimento", cf.dt_nascimento);
                err.IsClienteDataNascimentoValid = false;
                return false;
            }
            else err.IsClienteDataNascimentoValid = true;

            //Valida RendaMensal
            if (!IsRendaMensal(cf.renda_mensal))
            {
                clienteERR.dados.Add("renda_mensal",cf.renda_mensal);
                err.IsClienteRendaMensalValid = false;
                return false;
            }
            else err.IsClienteRendaMensalValid = true;

            //Valida EstadoCivil
            if (!IsEstadoCivil(cf.estado_civil))
            {
                clienteERR.dados.Add("estado_civil", cf.estado_civil);
                err.IsClienteEstadoCivilValid = false;
                return false;
            }
            else err.IsClienteEstadoCivilValid = true;

            //Valida QtdDependentes
            if (!IsQtdDependentes(cf.dependentes))
            {
                clienteERR.dados.Add("dependentes", cf.dependentes);
                err.IsClienteQtdDependentesValid = false;
                return false;
            }
            else err.IsClienteQtdDependentesValid = true;


            clienteERR.StoreClienteErrors();

            return true;
        }


        
        //////////////////////////
        //VALIDATION METHODS
        private static bool IsNome(string? valor)
        {
            if (valor == null) return false;
            return valor.Length >= 5;
        }

        // Código IsCpf: https://macoratti.net/11/09/c_val1.htm
        private static bool IsCpf(string? cpf)
        {
            if (cpf == null) return false;
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

        private static bool IsDataNascimento(string? valor)
        {
            if (valor == null) return false;
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

        private static bool IsRendaMensal(string? valor)
        {
            if (valor == null) return false;

            return float.Parse(valor) >= 0;
        }

        private static bool IsEstadoCivil(string? value)
        {
            if (value == null) return false;
            if (value.Length == 1)
                foreach (var ec in Enum.GetNames(typeof(EC)))
                    if (value.ToUpper() == ec.ToString())
                        return true;
            return false;
        }

        private static bool IsQtdDependentes(string? qtd)
        {
            if (qtd == null) return false;
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