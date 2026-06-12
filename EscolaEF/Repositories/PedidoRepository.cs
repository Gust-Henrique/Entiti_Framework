using Microsoft.EntityFrameworkCore;
using EscolaEF.Data;
using EscolaEF.Models;

namespace EscolaEF.Repositories
{
    public class PedidoRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public List<Pedido> ListarComItens()
            => _context.Pedidos
                .Include(p => p.Itens)
                .ToList();

        public int TotalItens(int pedidoId)
        {
            var pedido = _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefault(p => p.Id == pedidoId);

            if (pedido == null || pedido.Itens == null) return 0;

            return pedido.Itens.Sum(i => i.Quantidade);
        }
    }
}
