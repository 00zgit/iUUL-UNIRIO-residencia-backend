using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Atividade03.Q1
{
    public class Errors
    {
        public bool IsClienteNomeValid = false;
        public bool IsClienteCPFValid = false;
        public bool IsClienteDataNascimentoValid = false;
        public bool IsClienteRendaMensalValid = false;
        public bool IsClienteEstadoCivilValid = false;
        public bool IsClienteQtdDependentesValid = false;

        public Dictionary<string, string>? dados { get; set; }
        private Dictionary<string, string>? erros { get; set; }

        public Errors()
        {
            dados = new Dictionary<string, string>();
            erros = new Dictionary<string, string>();
        }

        public void StoreClienteErrors()
        {
            string filename = "errors.json";

            string jsonstr = JsonSerializer.Serialize(this);

            File.WriteAllText(filename,jsonstr);

            return;
        }

    }
}
