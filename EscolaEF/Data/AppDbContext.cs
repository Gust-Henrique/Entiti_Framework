using Microsoft.EntityFrameworkCore;
using EscolaEF.Models;

namespace EscolaEF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }

        // Conexão configurada direto aqui (padrão Console App)
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connStr = "server=localhost;database=escola;user=root;password=positivo";
            options.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        }
    }
}
