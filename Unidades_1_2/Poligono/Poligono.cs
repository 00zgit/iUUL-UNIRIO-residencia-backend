using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01
{
    internal class Poligono
    {
        
        public List<Vertice> Vertices;
        
        public Poligono(Vertice v1,Vertice v2, Vertice v3)
        {
            this.Vertices = new List<Vertice>();

            if(v1.ComparaVertice(v2) || v2.ComparaVertice(v3))
            {
                throw new Exception("Quantidade mínima de Vértices no Polígono deverá ser maior ou igual a 3");
            }
            else
            {
                Vertices.Add(v1);
                Vertices.Add(v2);
                Vertices.Add(v3);
            }
        }

        public bool AddVertice(double x, double y)
        {
            Vertice v = new Vertice(x,y);
            foreach(Vertice vertice in Vertices)
            {
                if (v.ComparaVertice(vertice))
                {
                    return false;
                }
            }
            Vertices.Add(v);
            return true;
        }

        public void RemoveVertice(Vertice v)
        {
            foreach(Vertice vertice in Vertices)
            {
                if(vertice == v)
                {
                    Vertices.Remove(v);
                    if (Vertices.Count() < 3)
                    {
                        throw new Exception("Quantidade de vértices menor do que 3");
                    }
                }
            }
        }

        public double CalculaPerimetroPoligono(Poligono p)
        {
            double sum = 0;

            foreach(Vertice vertice in p.Vertices)
            {
                sum += vertice.Distancia(vertice);
            }

            return sum;
        }

        public int QtdVerticesPoligono(Poligono p)
        {
            return p.Vertices.Count();
        }
    }
}
