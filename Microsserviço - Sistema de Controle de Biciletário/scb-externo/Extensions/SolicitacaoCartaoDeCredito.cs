using AutoMapper;
using scb_externo.Data.Dto;
using scb_externo.Models;
using scb_externo.services;
using System.Net;

namespace scb_externo.Extensions
{
    public class SolicitacaoCartaoDeCredito : Solicitacao
    {
        public SolicitacaoCartaoDeCredito(CieloAPI cieloAPI, MailTrapAPI mailTrapAPI, IMapper mapper, CobrancaDto cobranca, StripeAPI stripeAPI, AluguelAPI aluguelAPI)
            : base(cieloAPI, mailTrapAPI, mapper, cobranca, stripeAPI, aluguelAPI) { }

        public async Task<bool> EnviaValidacao(NovoCartaoDeCredito novoCartao)
        {
            ObjetoSalvavel = _mapper.Map<NovoCartaoDeCredito, CartaoDeCredito>(novoCartao);
            StatusSolicitacao = 200;

            var resposta = await _cieloAPI.ProcessaValidacao(novoCartao);

            if (!resposta.IsSuccessStatusCode)
            {
                switch (resposta.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        {
                            StatusSolicitacao = 404;
                            ObjetoSalvavel = new Erro { Codigo = StatusSolicitacao.ToString(), Mensagem = "Não encontrado" };
                            return false;
                        }
                    default:
                        {
                            StatusSolicitacao = 422;
                            ObjetoSalvavel = new Erro { Codigo = StatusSolicitacao.ToString(), Mensagem = "Dados inválidos" };
                            return false;
                        }
                }
            }

            return true;
        }
    }
}
