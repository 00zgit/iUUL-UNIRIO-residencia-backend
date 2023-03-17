using AutoMapper;
using scb_externo.Data;
using scb_externo.Data.Dto;
using scb_externo.services;

namespace scb_externo.Extensions
{
    public class Solicitacao
    {
        public CieloAPI _cieloAPI;
        public MailTrapAPI _mailTrapAPI;
        public IMapper _mapper;
        public CobrancaDto _cobrancaDto;
        public StripeAPI _stripeAPI;
        public AluguelAPI _aluguelAPI;
        public Solicitacao(CieloAPI cieloAPI, MailTrapAPI mailTrapAPI, IMapper mapper, CobrancaDto cobranca, StripeAPI stripeAPI, AluguelAPI aluguelAPI)
        {
            _cieloAPI = cieloAPI;
            _mailTrapAPI = mailTrapAPI;
            _mapper = mapper;
            _cobrancaDto = cobranca;
            _stripeAPI = stripeAPI;
            _aluguelAPI = aluguelAPI;
        }

        public int StatusSolicitacao;
        public ObjetoSalvavel ObjetoSalvavel;
    }
}
