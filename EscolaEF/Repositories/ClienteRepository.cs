using EscolaEF.Data;
using EscolaEF.Models;

namespace EscolaEF.Repositories
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public bool Adicionar(Cliente c)
        {
            if (string.IsNullOrEmpty(c.Email) || !c.Email.Contains('@') || !c.Email.Contains('.'))
            {
                Console.WriteLine("E-mail inválido. Cliente não salvo.");
                return false;
            }

            _context.Clientes.Add(c);
            _context.SaveChanges();
            return true;
        }

        public List<Cliente> Listar()
            => _context.Clientes.ToList();

        public Cliente? BuscarPorId(int id)
            => _context.Clientes.FirstOrDefault(c => c.Id == id);

        public Cliente? BuscarPorEmail(string email)
            => _context.Clientes
                .FirstOrDefault(c => c.Email == email);

        public void Atualizar(Cliente cliente)
        {
            var existente = _context.Clientes.Find(cliente.Id);
            if (existente != null)
            {
                existente.Nome  = cliente.Nome;
                existente.Email = cliente.Email;
                _context.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
