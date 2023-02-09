using Consultorio.Model;
using Consultorio.View;
using ConsultorioOdontoDB;
using ConsultorioOdontoDB.control.consulta;
using ConsultorioOdontoDB.control.paciente;
using ConsultorioOdontoDB.Controller;

namespace ConsultorioOdontoDB
{
    public class ApplicationController
    {


        public ApplicationController() { }


        public void Start()
        {
            int escolhaMenuPrincipal;
            int? escolhaCadastroPaciente;
            int? escolhaAgenda;
            var vm = new ViewMenu();
        MENU:
            escolhaCadastroPaciente = null;
            escolhaAgenda = null;

            escolhaMenuPrincipal = vm.MenuPrincipal();

            switch (escolhaMenuPrincipal)
            {
                case 1:
                    escolhaCadastroPaciente = vm.MenuCadastroPaciente();
                    break;
                case 2:
                    escolhaAgenda = vm.MenuAgenda();
                    break;
                default: return;
            }

            if (escolhaCadastroPaciente != null)
            {
                switch (escolhaCadastroPaciente)
                {
                    case 1:
                        {
                            CadastroPacienteController cpc = new();
                            cpc.CadastramentoPaciente();
                        }
                        break;
                    case 2:
                        {
                            RemocaoPacienteController rpc = new();
                            rpc.RemocaoPaciente();
                        }
                        break;
                    case 3:
                        {
                            ListagemPacienteController lpc = new();
                            lpc.ListagemPacienteCPF();
                        }
                        break;
                    case 4:
                        {
                            ListagemPacienteController lpc = new();
                            lpc.ListagemPacienteNome();
                        }
                        break;
                   default: break;
                }
            }

            else if (escolhaAgenda != null)
            {
                switch (escolhaAgenda)
                {
                    case 1:
                        {
                            AdicionarConsultaController acc = new();
                            acc.CriacaoConsulta();
                        }
                        break;
                    case 2:
                        {
                            RemocaoConsultaController rcc = new();
                            rcc.RemocaoConsulta();
                        }
                        break;
                    case 3:
                        {
                            int escolha = vm.MenuListagemAgenda();
                            switch(escolha)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Implementar em ViewController");
                                        //ViewListagem.ExibeAgenda(gerenciaPaciente);
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("Implementar em ViewController");
                                        /*var datas = ViewCadastro.InsereDataInicialFinalValida();
                                        ViewListagem.ExibeAgendaPeriodo(agenda, datas, gerenciaPaciente);*/
                                    }
                                    break;
                                default: break;
                            }
                        }
                        break;
                    default : break;
                }
            }

            // Ao final de toda execução,
            // voltaremos sempre ao menu principal
            // resetando os valores das escolhas.
            goto MENU;
        }
    }
}
