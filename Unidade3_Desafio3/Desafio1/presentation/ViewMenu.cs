using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Validators;

namespace Consultorio.View
{
    public class ViewMenu : IMenuViewValidavel
    {
        public int MenuPrincipal()
        {
            string? escolha;
            do
            {
                Console.WriteLine("\nMenu Principal" +
                "\n1-Cadastro de Pacientes" +
                "\n2-Agenda" +
                "\n3-Fim");

                escolha = Console.ReadLine();
            }
            while (!ValidaEscolha(escolha,3));

            return int.Parse(escolha);
        }

        public int MenuCadastroPaciente()
        {
            string? escolha;
            do
            {
                Console.WriteLine("\nMenu do Cadastro de Pacientes" +
                    "\n1-Cadastrar novo paciente" +
                    "\n2-Excluir paciente" +
                    "\n3-Listar pacientes (ordenado por CPF)" +
                    "\n4-Listar pacientes (ordenado por nome)" +
                    "\n5-Voltar p/ menu principal");

                escolha = Console.ReadLine();
            }
            while (!ValidaEscolha(escolha, 5));

            return int.Parse(escolha);
        }

        public int MenuAgenda()
        {
            string? escolha;
            do
            {
                Console.WriteLine("\nAgenda" +
                    "\n1-Agendar consulta" +
                    "\n2-Cancelar agendamento" +
                    "\n3-Listar agenda" +
                    "\n4-Voltar p/ Menu Principal");

                escolha = Console.ReadLine();
            }
            while (!ValidaEscolha(escolha, 4));

            return int.Parse(escolha);
        }

        public int MenuListagemAgenda()
        {
            string? escolha;
            do
            {
                Console.WriteLine("\nListar agenda" +
                "\n1-Listar agenda completa" +
                "\n2-Listar agenda por período" +
                "\n3-Voltar p/ Menu Principal");

                escolha = Console.ReadLine();
            }
            while (!ValidaEscolha(escolha, 3));

            return int.Parse(escolha);
        }

        public bool ValidaEscolha(string? entrada, int tipoMenu)
        {
            if(entrada == null) return false;

            int escolha;
            try
            {
                escolha = int.Parse(entrada);
            }
            catch
            {
                return false;
            }

            switch (tipoMenu)
            {
                case 3:
                {
                    return escolha >= 1 && escolha <= tipoMenu;
                }
                case 4:
                {
                    return escolha >= 1 && escolha <= tipoMenu;
                }
                case 5:
                {
                    return escolha >= 1 && escolha <= tipoMenu;
                }
                default: return false;
            }
        }
}
}
