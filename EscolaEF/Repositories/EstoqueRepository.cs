using EscolaEF.Data;
using EscolaEF.Models;

namespace EscolaEF.Repositories
{
    public class EstoqueRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(ItemEstoque item)
        {
            _context.Estoque.Add(item);
            _context.SaveChanges();
        }

        public List<ItemEstoque> Listar()
            => _context.Estoque.ToList();

        public bool DarBaixa(int id, int quantidade)
        {
            var item = _context.Estoque.Find(id);
            if (item == null) return false;

            if (item.Quantidade - quantidade < 0)
            {
                Console.WriteLine($"Estoque insuficiente para '{item.Nome}'. " +
                                  $"Disponível: {item.Quantidade}");
                return false;
            }

            item.Quantidade -= quantidade;
            _context.SaveChanges();
            return true;
        }

        public List<ItemEstoque> ListarEstoqueBaixo(int minimo = 5)
            => _context.Estoque
                .Where(i => i.Quantidade <= minimo)
                .ToList();
    }
}
