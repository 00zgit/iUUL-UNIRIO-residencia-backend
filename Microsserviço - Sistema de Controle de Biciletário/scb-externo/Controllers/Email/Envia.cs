using Microsoft.AspNetCore.Mvc;
using scb_externo.Data;
using scb_externo.Data.Dto;
using scb_externo.Extensions;
using scb_externo.Migrations;
using scb_externo.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace scb_externo.Controllers.email
{
    public class Envia : Externo
    {
        private SolicitacaoEmail _solicitacao;
        private ObjetoSalvavel _objSalvavel;

        public Envia(ObjetoSalvavel objSalvavel, SolicitacaoEmail solicitacao)
        {
            _objSalvavel = objSalvavel;
            _solicitacao = solicitacao;
        }

        [HttpPost("enviarEmail")]
        [ProducesResponseType(200, Type = typeof(Email))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        [ProducesResponseType(422, Type = typeof(Erro))]
        public IActionResult EnviarEmail(NovoEmail novoEmail)
        {
            _solicitacao.EnviaEmail(novoEmail);

            _objSalvavel.Save(_solicitacao.ObjetoSalvavel);

            return StatusCode(_solicitacao.StatusSolicitacao, _solicitacao.ObjetoSalvavel);
        }
    }
}
