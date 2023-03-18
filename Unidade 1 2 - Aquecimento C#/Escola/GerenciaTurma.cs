using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Aluno_Q2
{
    internal class GerenciaTurma : IComparer<Aluno>
    {
        private float mediaP1 { get; set; }
        private float mediaP2 { get; set; }
        private float mediaPF { get; set; }

        public int Compare(Aluno? x, Aluno? y)
        {
            if(x.nome == null || y.nome == null)
            {
                return 0;
            }
            return x.nome.CompareTo(y.nome);
        }

        public List<float> CalculaEstatistica(Turma t)
        {
            List<float> medias = new();

            float somaMedia1 = 0;
            foreach (var aluno in t.Alunos)
            {
                somaMedia1 += aluno.P1;
            }
            this.mediaP1 = somaMedia1 / t.Alunos.Count;
            medias.Add(mediaP1);

            float somaMedia2 = 0;
            foreach (var aluno in t.Alunos)
            {
                somaMedia2 += aluno.P2;
            }
            this.mediaP2 = somaMedia2 / t.Alunos.Count;
            medias.Add(mediaP2);

            float somaMediaF = 0;
            foreach (var aluno in t.Alunos)
            {
                somaMediaF += aluno.P2;
            }
            this.mediaPF = somaMediaF / t.Alunos.Count;
            medias.Add(mediaPF);

            return medias;
        }

        public void ImprimeTurmaNotaFinal(Turma t)
        {
            t.Alunos.Sort(this);
            foreach (var aluno in t.Alunos)
            {
                Console.WriteLine("Nome: " + aluno.nome);
                Console.WriteLine("Nota final: " + aluno.PF);
            }
        }

        public void ImprimeTurmaEstatistica(Turma t)
        {
            GerenciaTurma gt = new();
            List<float> medias = gt.CalculaEstatistica(t);

            Console.WriteLine("\n....Imprimindo Estatísticas da Turma....");
            Console.WriteLine("Média P1: " + medias[0]);
            Console.WriteLine("Média P2: " + medias[1]);
            Console.WriteLine("Média PF: " + medias[2]);
        }
    }
}
