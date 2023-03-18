using Microsoft.AspNetCore.Mvc;
using scb_externo.Data;
using scb_externo.Extensions;
using scb_externo.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace scb_externo.Controllers.cartaoDeCredito
{
    
    public class Valida : Externo
    {
        private ObjetoSalvavel _objSalvavel;
        private SolicitacaoCartaoDeCredito _solicitacao;
        public Valida(ObjetoSalvavel objSalvavel, SolicitacaoCartaoDeCredito solicitacao)
        {
            _objSalvavel = objSalvavel;
            _solicitacao = solicitacao;
        }

        [HttpPost("validaCartaoDeCredito")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404, Type = typeof(Erro))]
        [ProducesResponseType(422, Type = typeof(Erro))]
        public async Task<IActionResult> ValidarCartaoDeCredito(NovoCartaoDeCredito novoCartao)
        {
            await _solicitacao.EnviaValidacao(novoCartao).ConfigureAwait(false);
            
            _objSalvavel.Save(_solicitacao.ObjetoSalvavel);

            return StatusCode(_solicitacao.StatusSolicitacao, _solicitacao.ObjetoSalvavel);
        }
    }
}
