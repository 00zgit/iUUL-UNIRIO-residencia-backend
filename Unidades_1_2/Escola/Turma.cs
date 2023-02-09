using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Turma : IComparer<Aluno>
    {
        protected internal List<Aluno> Alunos { get; set; }
        private String codigo = "TURMA";

        public int Compare(Aluno? x, Aluno? y)
        {
            if (x.nome == null || y.nome == null)
            {
                return 0;
            }
            return x.nome.CompareTo(y.nome);
        }

        protected internal String Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                //gerando número aleatório
                Random r = new();
                String random = r.Next(0, 999).ToString();

                //removendo whitespaces do parâmetro e transformando em maiúsculo
                value = value.Trim().ToUpper();

                //gerando código "único"
                codigo = codigo + value + random;
            }
        }

        public Turma(String codigo, List<Aluno> alunos)
        {
            Alunos = new();
            this.Codigo = codigo;
            foreach (var aluno in alunos)
                this.InsereAlunoTurma(aluno);
        }

        public void InsereAlunoTurma(Aluno a)
        {
            // não pode haver aluno repetido na mesma turma
            for(int i = 0; i < this.Alunos.Count; i++)
            {
                var aluno = this.Alunos[i];
                if (a.Equals(aluno))
                {
                    Console.WriteLine("[ERRO] Aluno "+a.matricula+" já inserido na turma "+this.codigo);
                    return;
                }
            }
            this.Alunos.Add(a);
            Console.WriteLine("[SUCESSO] Aluno "+a.matricula+" inserido na turma "+this.codigo);
        }
        public void RemoveAlunoTurma(Aluno a)
        {
            this.Alunos.Remove(a);
            Console.WriteLine($"[SUCESSO] Aluno {a.matricula} removido da turma {this.codigo}");
        }

        public void ImprimeAlunos()
        {
            this.Alunos.Sort(this);
            Console.WriteLine("Imprimindo alunos em ordem alfabética...");
            foreach(var aluno in this.Alunos)
            {
                Console.WriteLine(aluno.nome);
            }
        }
    }
}
