using AutoMapper;
using scb_externo.Data.Dto;
using scb_externo.Models;
using scb_externo.services;
using System.Net.Mail;

namespace scb_externo.Extensions
{
    public class SolicitacaoEmail : Solicitacao
    {
        public SolicitacaoEmail(CieloAPI cieloAPI, MailTrapAPI mailTrapAPI, IMapper mapper, CobrancaDto cobranca, StripeAPI stripeAPI, AluguelAPI aluguelAPI)
            : base(cieloAPI, mailTrapAPI, mapper, cobranca, stripeAPI, aluguelAPI) { }

        public bool EnviaEmail(NovoEmail novoEmail)
        {
            ObjetoSalvavel = _mapper.Map<NovoEmail, Email>(novoEmail);
            StatusSolicitacao = 200;

            try
            {
                _mailTrapAPI.enviarEmail(novoEmail);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case SmtpFailedRecipientException:
                        {
                            StatusSolicitacao = 404;
                            ObjetoSalvavel = new Erro { Codigo = StatusSolicitacao.ToString(), Mensagem = "E-mail não existe" };
                            return false;
                        }
                    case SmtpException:
                        {
                            StatusSolicitacao = 422;
                            ObjetoSalvavel = new Erro { Codigo = StatusSolicitacao.ToString(), Mensagem = "E-mail com formato inválido" };
                            return false;
                        }
                    default:
                        {
                            StatusSolicitacao = 500;
                            ObjetoSalvavel = new Erro { Codigo = StatusSolicitacao.ToString(), Mensagem = "Internal server error" };
                            return false;
                        }
                }
            }

            return true;
        }
    }
}
