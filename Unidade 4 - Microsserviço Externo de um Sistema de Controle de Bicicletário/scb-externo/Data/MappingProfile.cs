using AutoMapper;
using scb_externo.Models;

namespace scb_externo.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NovoEmail, Email>();
            CreateMap<NovoCartaoDeCredito, CartaoDeCredito>();
            CreateMap<NovaCobranca, Cobranca>();
            CreateMap<Cobranca, NovaCobranca>();
        }
    }
}
