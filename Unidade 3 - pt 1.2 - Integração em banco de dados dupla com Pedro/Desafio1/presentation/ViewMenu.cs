using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Validators;

namespace Consultorio.View
{
    public class ViewMenu
    {
        public int escolhaMenuPrincipal { get; private set; }
        public int? escolhaCadastroPaciente { get; private set; }
        public int? escolhaAgenda { get; private set; }
        public int escolhaListagemAgenda { get; private set; }

        public ViewMenu() { }


        public void MenuPrincipal()
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

            this.escolhaMenuPrincipal = int.Parse(escolha);
        }

        public void MenuCadastroPaciente()
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

            this.escolhaCadastroPaciente = int.Parse(escolha);
        }

        public void MenuAgenda()
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

            this.escolhaAgenda = int.Parse(escolha);
        }

        public void MenuListagemAgenda()
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

            this.escolhaListagemAgenda = int.Parse(escolha);
        }

        private bool ValidaEscolha(string? entrada, int tipoMenu)
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

        internal void Reset()
        {
            this.escolhaCadastroPaciente = null;
            this.escolhaAgenda = null;
        }
    }
}
