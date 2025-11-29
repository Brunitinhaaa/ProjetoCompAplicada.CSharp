using ProjetoCompAplicada.CSharp.Data;
using ProjetoCompAplicada.CSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCompAplicada.CSharp.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Servico> GetAll() =>
            _context.Servicos.AsNoTracking().ToList();

        public IEnumerable<Servico> GetByNome(string nome) =>
            _context.Servicos
                .AsNoTracking()
                .Where(s => s.Nome.Contains(nome))
                .ToList();
    }
}
