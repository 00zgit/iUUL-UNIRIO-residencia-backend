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
        public ViewMenu viewMenu;

        public ApplicationController()
        {
            viewMenu = new ViewMenu();
        }


        public void Start()
        {

        MENU:
            viewMenu.Reset();
            viewMenu.MenuPrincipal();


            switch (viewMenu.escolhaMenuPrincipal)
            {
                case 1:
                    viewMenu.MenuCadastroPaciente();
                    break;
                case 2:
                    viewMenu.MenuAgenda();
                    break;
                default: return;
            }

            if(viewMenu.escolhaCadastroPaciente != null)
            {
                switch (viewMenu.escolhaCadastroPaciente)
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
            

            else if(viewMenu.escolhaAgenda != null)
            {
                switch (viewMenu.escolhaAgenda)
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
                            viewMenu.MenuListagemAgenda();
                            switch (viewMenu.escolhaListagemAgenda)
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
                    default: break;
                }
            }
            

            
            goto MENU;
        }
    }
}
