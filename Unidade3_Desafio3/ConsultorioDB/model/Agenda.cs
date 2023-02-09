using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultorioDB.view.forms;

namespace ConsultorioDB
{
    public class Agenda
    {
        public List<Consulta> Consultas { get; set; }

        public Agenda()
        {
            Consultas = new List<Consulta>();
        }
    }
}
