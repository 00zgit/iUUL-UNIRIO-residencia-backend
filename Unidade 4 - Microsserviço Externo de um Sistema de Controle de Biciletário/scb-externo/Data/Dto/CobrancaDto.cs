using scb_externo.Extensions;
using scb_externo.Models;
using scb_externo.Models.Enum;

namespace scb_externo.Data.Dto
{
    public class CobrancaDto
    {
        private ExternoContext Context;
        
        public CobrancaDto(ExternoContext context)
        {
            this.Context = context;
        }

        public List<Cobranca>? GetCobrancasFila()
        {

            var cbc = Context.Cobrancas.Where(c => !c.Status.Equals(StatusCobranca.PAGA.ParaString()) &&
                                                !c.Status.Equals(StatusCobranca.CANCELADA.ParaString()));
            return cbc.ToList();
        }
        public List<Cobranca> GetAllCobrancas()
        {
            return Context.Cobrancas.ToList();
        }

        public void AtualizaCobranca(Cobranca cobranca)
        {
            Context.Cobrancas.Update(cobranca);
            Context.SaveChanges();
        }
    }
}
