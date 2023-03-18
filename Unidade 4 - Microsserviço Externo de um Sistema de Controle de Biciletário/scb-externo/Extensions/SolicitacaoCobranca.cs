using scb_externo.services;
using AutoMapper;
using scb_externo.Models;
using scb_externo.Models.Enum;
using scb_externo.Data.Dto;
using System.Text.Json;

namespace scb_externo.Extensions
{
    public class SolicitacaoCobranca : Solicitacao
    {
        public SolicitacaoCobranca(CieloAPI cieloAPI, MailTrapAPI mailTrapAPI, IMapper mapper, CobrancaDto cobranca, StripeAPI stripeAPI, AluguelAPI aluguelAPI)
            : base(cieloAPI, mailTrapAPI, mapper, cobranca, stripeAPI, aluguelAPI) { }

        public StatusCobranca sts;//Optei por criar essa variável, pois não tinha como eu recuperar o status da solicitação chamando a função RealizarCobranca() pela função ProcessarCobrancas

        public async Task<bool> RealizaCobrancaAsync(NovaCobranca novaCobranca)
        {
            var cobranca = _mapper.Map<NovaCobranca, Cobranca>(novaCobranca);
            ObjetoSalvavel = cobranca;
            cobranca.HoraSolicitacao = DateTime.UtcNow;
            StatusSolicitacao = 200;

            var url = "https://residencia-nebula.ed.dev.br/aluguel-grupo1/cartaoDeCredito/" + novaCobranca.IdCiclista.ToString();
            var response = await _aluguelAPI.RecuperaCartaoPorID(url);

            if (response != null)
            {
                var json = response.RootElement;

                CartaoDeCredito cartao = new CartaoDeCredito
                {
                    Numero = json.GetProperty("numero").Deserialize<string>(),
                    Validade = json.GetProperty("validade").Deserialize<string>(),
                    Cvv = json.GetProperty("cvv").Deserialize<string>(),
                };

                var resposta = _stripeAPI.EnviaCobranca(cartao, cobranca.Valor);

                if (resposta == StatusCobranca.PAGA)
                {
                    cobranca.HoraFinalizacao = DateTime.UtcNow;
                }

                cobranca.Status = resposta.ParaString();
                sts = resposta; 
                return true;
            }

            StatusSolicitacao = 422;
            ObjetoSalvavel = new Erro { Codigo = "422", Mensagem = "Dados inválidos, ciclista não encontrado." };

            return false;
        }

        public async Task<bool> IncluiCobrancaAsync(Cobranca cobranca)
        {
            cobranca.HoraSolicitacao = DateTime.UtcNow;
            cobranca.Status = StatusCobranca.PENDENTE.ParaString();

            var url = "https://residencia-nebula.ed.dev.br/aluguel-grupo1/ciclista/" + cobranca.IdCiclista.ToString();
            var response = await _aluguelAPI.RecuperaCiclistaPorID(url);

            if (response != null)
            {
                ObjetoSalvavel = cobranca;
                StatusSolicitacao = 200;
                return true;
            }

            cobranca.Status = StatusCobranca.FALHA.ParaString();
            StatusSolicitacao = 422;
            ObjetoSalvavel = new Erro { Codigo = "422", Mensagem = "Dados inválidos" };
            return false;
        }
    }
}
