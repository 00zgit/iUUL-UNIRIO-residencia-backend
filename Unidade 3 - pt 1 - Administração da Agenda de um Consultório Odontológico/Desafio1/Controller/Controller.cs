using Consultorio.Form;
using Consultorio.Model;
using Consultorio.View;

namespace Consultorio.Controller
{
    internal static class Controller
    {
        public static void Start()
        {
            /*******************************************
             * Criaremos a lista de Consultas e Pacientes
             * apenas uma única vez durante a execução
             * do programa.
             ******************************************/
            Agenda agenda = new();
            GerenciaPaciente gerenciaPaciente = new();

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
                            PacienteForm pacienteForm = new();

                            pacienteForm = ViewCadastro.CadastroPaciente(pacienteForm,gerenciaPaciente);

                            Paciente p = new(pacienteForm.Nome, pacienteForm.CPF, DateTime.Parse(pacienteForm.DataNascimento));

                            gerenciaPaciente.Pacientes.Add(p);

                            ViewMensagens.ExibeMensagemCadastroPaciente();
                        }
                        break;
                    case 2:
                        {
                            PacienteForm pf = new();
                            var cpfRemover = ViewCadastro.InsereCPFValidoExistente(gerenciaPaciente,pf); // Inserir um CPF.

                            try
                            {
                                gerenciaPaciente.RemovePaciente(cpfRemover);
                            }
                            catch
                            {
                                ViewMensagens.ExibeMensagemRemocaoPaciente(false);
                                break;
                            }
                            ViewMensagens.ExibeMensagemRemocaoPaciente(true);
                        }
                        break;
                    case 3:
                        {
                            // ordena a lista de pacientes utilizando o Cpf como criterio de ordenacao
                            //Depois Retorna para o view a lista ordenada para ser printada
                            gerenciaPaciente.Pacientes.Sort((a1, a2) => a1.CPF.CompareTo(a2.CPF));
                            ViewListagem.ExibeListaPacientes(gerenciaPaciente.Pacientes);
                        }
                        break;
                    case 4:
                        {
                            // ordena a lista de pacientes utilizando o Nome como criterio de ordenacao
                            //Depois Retorna para o view a lista ordenada para ser printada
                            gerenciaPaciente.Pacientes.Sort((a1, a2) => a1.Nome.CompareTo(a2.Nome));
                            ViewListagem.ExibeListaPacientes(gerenciaPaciente.Pacientes);
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
                            ConsultaForm consultaForm = new();
                            PacienteForm pf = new();
                            consultaForm = ViewCadastro.InsereDadosConsulta(gerenciaPaciente, consultaForm,pf);

                            //Verificar se o cpf inserido para consulta está cadastrado no sistema
                            Paciente? paciente = gerenciaPaciente.RetornaPaciente(consultaForm.CPF);
                            if (paciente == null)
                            {
                                ViewMensagens.ExibeMensagemErroCPFCadastrado(false);
                                break;
                            }

                            // Se estiver, verificar sobreposição de consultas
                            Consulta consulta = new(consultaForm.CPF,
                                DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta)),
                                consultaForm.HoraInicial, consultaForm.HoraFinal);
                            try
                            {
                                paciente.Consulta = consulta;
                            }
                            catch
                            {
                                // Exibir mensagem de erro
                                ViewMensagens.ExibeMensagemAgendamento(false);
                                break;
                            }

                            // Adicionando consulta na agenda
                            Agenda.Consultas.Add(consulta);

                            // Exibir mensagem de sucesso
                            ViewMensagens.ExibeMensagemAgendamento(true);
                        }
                        break;
                    case 2:
                        {
                            ConsultaForm consultaForm = new();
                            PacienteForm pf = new();
                            consultaForm = ViewCadastro.InsereDadosCancelamentoConsulta(gerenciaPaciente,consultaForm,pf);

                            try
                            {
                                agenda.RemoveConsulta(consultaForm);
                            }
                            catch
                            {
                                ViewMensagens.ExibeMensagemCancelarConsulta(false);
                                break;
                            }

                            // Se o try for realizado com sucesso,
                            // removemos a consulta associada ao paciente.
                            Paciente? pacienteRemoverConsulta = gerenciaPaciente.RetornaPaciente(consultaForm.CPF);
                            
                            if(pacienteRemoverConsulta != null)
                                pacienteRemoverConsulta.Consulta = null;

                            ViewMensagens.ExibeMensagemCancelarConsulta(true);
                        }
                        break;
                    case 3:
                        {
                            int escolha = vm.MenuListagemAgenda();
                            switch(escolha)
                            {
                                case 1:
                                    {
                                        ViewListagem.ExibeAgenda(gerenciaPaciente);
                                    }
                                    break;
                                case 2:
                                    {
                                        var datas = ViewCadastro.InsereDataInicialFinalValida();
                                        ViewListagem.ExibeAgendaPeriodo(agenda, datas, gerenciaPaciente);
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
