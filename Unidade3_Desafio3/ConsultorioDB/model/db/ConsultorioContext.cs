using ConsultorioDB;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioDB
{
    internal class ConsultorioContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConsultorioDB;Trusted_Connection=true;");
        }
    }
}