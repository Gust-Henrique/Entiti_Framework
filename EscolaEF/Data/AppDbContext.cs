using Microsoft.EntityFrameworkCore;
using EscolaEF.Models;

namespace EscolaEF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<ItemEstoque> Estoque { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Pedido>     Pedidos      { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connStr = "server=localhost;database=escola;user=root;password=positivo";
            options.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        }
    }
}
