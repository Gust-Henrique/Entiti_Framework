using EscolaEF.Data;
using EscolaEF.Models;

namespace EscolaEF.Repositories
{
    public class CursoRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Curso c)
        {
            _context.Cursos.Add(c);
            _context.SaveChanges();
        }

        public List<Curso> ListarOrdenadoPorNome()
            => _context.Cursos.OrderBy(c => c.Nome).ToList();

        public List<Curso> FiltrarPorCargaHoraria(int minimo)
            => _context.Cursos
                .Where(c => c.CargaHoraria >= minimo)
                .OrderBy(c => c.Nome)
                .ToList();
    }
}
