using EscolaEF.Data;
using EscolaEF.Models;

namespace EscolaEF.Repositories
{
    public class ProdutoRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
        }

        public List<Produto> Listar()
            => _context.Produtos.ToList();

        public Produto? BuscarPorId(int id)
            => _context.Produtos.FirstOrDefault(p => p.Id == id);

        public void Atualizar(Produto produto)
        {
            var existente = _context.Produtos.Find(produto.Id);
            if (existente != null)
            {
                existente.Nome  = produto.Nome;
                existente.Preco = produto.Preco;
                _context.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }

        public List<Produto> ListarAcimaDePreco(double precoMinimo)
            => _context.Produtos
                .Where(p => p.Preco > precoMinimo)
                .OrderBy(p => p.Preco)
                .ToList();
    }
}
