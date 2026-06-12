using EscolaEF.Data;
using EscolaEF.Models;

namespace EscolaEF.Repositories
{
    public class EstudanteRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        // CREATE — adiciona estudante ao banco
        public void Adicionar(Estudante e)
        {
            _context.Estudantes.Add(e);
            _context.SaveChanges();
        }

        // READ — lista todos os estudantes
        public List<Estudante> Listar()
        {
            return _context.Estudantes.ToList();
        }

        // READ — busca por ID (retorna null se não existir)
        public Estudante? BuscarPorId(int id)
        {
            return _context.Estudantes.FirstOrDefault(e => e.Id == id);
        }

        // UPDATE — atualiza nome e idade
        public void Atualizar(Estudante estudante)
        {
            var existente = _context.Estudantes.Find(estudante.Id);
            if (existente != null)
            {
                existente.Nome  = estudante.Nome;
                existente.Idade = estudante.Idade;
                _context.SaveChanges();
            }
        }

        // DELETE — remove pelo ID
        public void Remover(int id)
        {
            var estudante = _context.Estudantes.Find(id);
            if (estudante != null)
            {
                _context.Estudantes.Remove(estudante);
                _context.SaveChanges();
            }
        }
    }
}
