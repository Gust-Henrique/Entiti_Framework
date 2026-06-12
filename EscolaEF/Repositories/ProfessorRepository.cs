using Microsoft.EntityFrameworkCore;
using EscolaEF.Data;
using EscolaEF.Models;

namespace EscolaEF.Repositories
{
    public class ProfessorRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
        }

        public List<Professor> ListarComCursos()
            => _context.Professores
                .Include(p => p.Cursos)
                .ToList();
    }
}
