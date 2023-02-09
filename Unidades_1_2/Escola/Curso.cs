using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Aluno_Q3
{
    internal class Curso
    {
        private String nome { get; set; }
        private List<Aluno> alunosDoCurso;
        protected internal List<Turma> turmasDoCurso;


        public void RemoveTurmaCurso(Turma t)
        {
            for(int i = 0; i < this.turmasDoCurso.Count; i++)
            {
                var turma = this.turmasDoCurso[i];
                if (t.Equals(turma))
                    if (t.Alunos.Count == 0) // só será possível remover a Turma de um Curso caso não hajam alunos nela
                    {
                        this.turmasDoCurso.Remove(t);
                        Console.WriteLine("[SUCESSO] Turma "+t.Codigo+" removida do curso "+this.nome);
                    }
                    else
                        Console.WriteLine("[ERRO] Impossível excluir turma "+t.Codigo+" pois possui aluno.");
            }
        }

        public void AdicionaTurmaCurso(Turma t)
        {
            this.turmasDoCurso.Add(t);
        }

        public void ImprimeTurmasDoCurso()
        {
            Console.WriteLine("\nIMPRIMINDO DADOS DO CURSO DE: "+this.nome);
            Console.WriteLine("Quantidade de turmas: " + this.turmasDoCurso.Count);
            foreach (var turma in this.turmasDoCurso)
            {
                Console.WriteLine("\nCódigo da turma: "+turma.Codigo);
                Console.WriteLine("Quantidade de Alunos: "+ turma.Alunos.Count);
            }
        }
        public void ImprimeTurmasdoCursoComAlunos()
        {
            Console.WriteLine($"\n\nImprimindo Turmas por código com Alunos por nome do Curso de {this.nome}...");
            foreach (var turma in this.turmasDoCurso)
            {
                if(turma.Alunos.Count != 0)
                {
                    Console.WriteLine("\n"+turma.Codigo); //IComparer não funcionou ...
                    turma.ImprimeAlunos();
                }
            }
        }

        public Curso(string nome)
        {
            this.nome = nome;
            alunosDoCurso = new();
            turmasDoCurso = new();
        }

        public void MatriculaAlunoCurso(Aluno a)
        {
            this.alunosDoCurso.Add(a);
        }
        public void RemoveAlunoCurso(Aluno a)
        {
            bool alunoMatriculado = false;
            //percorrendo todos os alunos de todas as turmas para ver se o "Aluno a" está em alguma
            foreach(var turma in this.turmasDoCurso)
                foreach(var aluno in turma.Alunos)
                    if (aluno.matricula == a.matricula)
                        alunoMatriculado = true; // se achou, ele está matriculado.

            //remover o aluno se ele não estiver em alguma turma
            if (!alunoMatriculado)
            {
                this.alunosDoCurso.Remove(a);
                Console.WriteLine($"[SUCESSO] Aluno {a.matricula} removido do curso {this.nome}");
            }
                
            else
                Console.WriteLine($"[ERRO] Impossível remover aluno {a.matricula} do curso {this.nome} pois está em alguma turma.");
        }
    }
}
