using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using scb_externo.Data;
using scb_externo.Data.Dto;
using scb_externo.Extensions;
using scb_externo.Models;
using scb_externo.Models.Enum;

namespace scb_externo.Controllers.cobranca
{

    public class Cobra : Externo
    {
        private ObjetoSalvavel _objSalvavel;
        private SolicitacaoCobranca _solicitacao;
        private CobrancaDto _cobrancaDto;
        private IMapper _mapper;

        public Cobra(ObjetoSalvavel objSalvavel, SolicitacaoCobranca solicitacao, IMapper mapper, CobrancaDto cobrancaDto)
        {
            _objSalvavel = objSalvavel;
            _solicitacao = solicitacao;
            _mapper = mapper;
            _cobrancaDto = cobrancaDto;
        }

        [HttpPost("cobranca")]
        [ProducesResponseType(200, Type = typeof(Cobranca))]
        [ProducesResponseType(422, Type = typeof(Erro))]
        public async Task<IActionResult> RealizarCobranca(NovaCobranca cobranca)
        {
            var resposta = await _solicitacao.RealizaCobrancaAsync(cobranca);

            if (!resposta)
            {
                _objSalvavel.Save(_solicitacao.ObjetoSalvavel);
            }

            return StatusCode(_solicitacao.StatusSolicitacao, _solicitacao.ObjetoSalvavel);
        }

        [HttpPost("processaCobrancasEmFila")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(422, Type = typeof(Erro))]
        public async Task<IActionResult> ProcessarCobrancas()
        {
            var cobrancas = _cobrancaDto.GetCobrancasFila();

            if (cobrancas != null)
            {
                for (int i = 0; i < cobrancas.Count; i++)
                {
                    cobrancas[i].HoraSolicitacao = DateTime.UtcNow;
                    var aux = _mapper.Map<Cobranca, NovaCobranca>(cobrancas[i]);
                    await RealizarCobranca(aux);
                    if (_solicitacao.sts == StatusCobranca.PAGA)
                    {
                        cobrancas[i].HoraFinalizacao = DateTime.UtcNow;
                    }
                    cobrancas[i].Status = _solicitacao.sts.ParaString();
                    _cobrancaDto.AtualizaCobranca(cobrancas[i]);
                }
            }

            return StatusCode(StatusCodes.Status200OK, "Processamento concluído com sucesso");
        }

        [HttpPost("filaCobranca")]
        [ProducesResponseType(200, Type = typeof(Cobranca))]
        [ProducesResponseType(422, Type = typeof(Erro))]
        public async Task<IActionResult> AdicionarNovaCobrancaAsync(NovaCobranca novaCobranca)
        {
            var cobranca = _mapper.Map<NovaCobranca, Cobranca>(novaCobranca);
            await _solicitacao.IncluiCobrancaAsync(cobranca);

            _objSalvavel.Save(_solicitacao.ObjetoSalvavel);

            return StatusCode(_solicitacao.StatusSolicitacao, _solicitacao.ObjetoSalvavel);
        }
    }
}
