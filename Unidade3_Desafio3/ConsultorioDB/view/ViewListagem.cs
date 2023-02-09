using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ConsultorioDB.dao;
using ConsultorioDB.model;
using static System.Net.Mime.MediaTypeNames;

namespace ConsultorioDB
{
    internal static class ViewListagem
    {
        public static void ExibeListaPacientes(List<Paciente> listaPacientes)
        {
            int idade;
            //Metodo para listar pacientes, recebe uma lista ja ordenada pelo controlador e da o print nela
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("CPF\t\tNome\tDt.Nasc.\tIdade\t");
            Console.WriteLine("--------------------------------------------------");
            foreach (Paciente paciente in listaPacientes)
            {
                idade = DateTime.Now.Year - paciente.DataNascimento.Year;
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", paciente.CPF, paciente.Nome, DateOnly.FromDateTime(paciente.DataNascimento), idade);
                if(paciente.Consulta != null) {
                    Console.WriteLine("\t\tAgendado Para: " + paciente.Consulta.DataConsulta);
                    Console.WriteLine("\t\t{0} às {1}", FormataData(paciente.Consulta.HoraInicial), FormataData(paciente.Consulta.HoraFinal));
                }
            }
            Console.WriteLine("--------------------------------------------------");
        }

        
        internal static void ExibeAgenda(List<Consulta> consultas,List<Paciente> pacientes)
        {
            int tempoConsulta;
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Data\t\tH.Ini\tH.Fim\tTempo\tNome\tDt.Nasc.");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var c in consultas)
            {
                tempoConsulta = int.Parse(c.HoraFinal) - int.Parse(c.HoraInicial);
                var paciente = PacienteDAO.RetornaPaciente(c.CPF,pacientes);
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", 
                    c.DataConsulta, 
                    FormataData(c.HoraInicial), 
                    FormataData(c.HoraFinal), 
                    tempoConsulta, 
                    paciente.Nome, paciente.DataNascimento.ToString("dd/MM/yyyy"));
            }
            Console.WriteLine("---------------------------------------------------------------");
        }
        
        internal static void ExibeAgendaPeriodo(List<Consulta> consultas, string[] datas, List<Paciente> pacientes)
        {
            int tempoConsulta;
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Data\t\tH.Ini\tH.Fim\tTempo\tNome\tDt.Nasc.");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (Consulta consulta in consultas)
            {
                if(consulta.DataConsulta.CompareTo(
                    DateOnly.FromDateTime(DateTime.Parse(datas[0]))) > 0
                    &&
                    consulta.DataConsulta.CompareTo(
                        DateOnly.FromDateTime(DateTime.Parse(datas[1]))) < 0)
                {
                    tempoConsulta = int.Parse(consulta.HoraFinal) - int.Parse(consulta.HoraInicial);
                    var paciente = PacienteDAO.RetornaPaciente(consulta.CPF,pacientes);
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                        consulta.DataConsulta,
                        FormataData(consulta.HoraInicial),
                        FormataData(consulta.HoraFinal),
                        tempoConsulta,
                        paciente.Nome, paciente.DataNascimento.ToString("dd/MM/yyyy"));
                }
                if (consulta.DataConsulta.CompareTo(
                    DateOnly.FromDateTime(DateTime.Parse(datas[0]))) == 0
                    ||
                    consulta.DataConsulta.CompareTo(
                        DateOnly.FromDateTime(DateTime.Parse(datas[1]))) == 0)
                {
                    tempoConsulta = int.Parse(consulta.HoraFinal) - int.Parse(consulta.HoraInicial);
                    var paciente = PacienteDAO.RetornaPaciente(consulta.CPF, pacientes);
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                        consulta.DataConsulta,
                        FormataData(consulta.HoraInicial),
                        FormataData(consulta.HoraFinal),
                        tempoConsulta,
                        paciente.Nome, paciente.DataNascimento.ToString("dd/MM/yyyy"));
                }
            }
            Console.WriteLine("---------------------------------------------------------------");
        }

        //Metodo usado para formatar os horarios para o formato hh:mm
        private static string FormataData(string horario)
        {
            string hora = horario.Substring(0, 2);//Separa a string em horario e minutos
            string minutos = horario.Substring(2, 2);
            return hora + ":" + minutos; //junta as horas e minutos no formato desejado
        }
    }
}
