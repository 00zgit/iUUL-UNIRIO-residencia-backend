using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Aluno : Cursa
    {
        protected internal String nome { get; set; }
        protected internal String matricula = "2022";

        private String Matricula
        {
            get
            {
                return matricula;
            }
            set
            {
                //gerando matrícula a depender da data atual (ano, mês e dia)
                DateTime now = DateTime.Now;
                String ano = now.Year.ToString();
                String mes = now.Month.ToString();
                String dia = now.Day.ToString();
                String hashData = ano + mes + dia;

                //gerando número aleatório
                Random r = new();
                String random = r.Next(0, int.Parse(ano)).ToString();

                //removendo whitespaces do parâmetro e transformando em minúsculo
                value = value.Trim().ToLower();

                //gerando matrícula "única"
                matricula = value + hashData + random;
            }
        }

        public Aluno(string nome)
        {
            this.nome = nome;
            this.Matricula = nome;
        }

        public void LancaNota(Aluno a, float p1, float p2)
        {
            a.P1 = p1;
            a.P2 = p2;
            a.PF = (p1 + p2) / 2;
        }
    }
}
