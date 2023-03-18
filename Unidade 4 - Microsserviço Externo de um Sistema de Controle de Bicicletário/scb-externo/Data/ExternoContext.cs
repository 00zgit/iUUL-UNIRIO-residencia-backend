using Microsoft.EntityFrameworkCore;
using scb_externo.Models;

namespace scb_externo.Data
{
    public class ExternoContext : DbContext
    {
        public ExternoContext(DbContextOptions<ExternoContext> options)
            : base(options)
        {

        }

        public DbSet<Email> Emails { get; set; }
        public DbSet<Erro> Erros { get; set; }
        public DbSet<Cobranca> Cobrancas { get; set; }
    }
}
