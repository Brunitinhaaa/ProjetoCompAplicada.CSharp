using Microsoft.EntityFrameworkCore;
using ProjetoCompAplicada.CSharp.DTOs.Paginacao;
using ProjetoCompAplicada.CSharp.Models;
using ProjetoCompAplicada.CSharp.Data;
using ProjetoCompAplicada.CSharp.UseCases.Pagination;

namespace ProjetoCompAplicada.CSharp.UseCases.Servicos
{
    public class ServicosUseCase
    {
        private readonly AppDbContext _context;

        public ServicosUseCase(AppDbContext context)
        {
            _context = context;
        }

        // MÉTODO PRINCIPAL COM PAGINAÇÃO + ORDENAÇÃO
        public async Task<PagedResult<Servico>> GetAllAsync(PaginationParameters p)
        {
            var query = _context.Servicos.AsQueryable();

            // garantir valores padrão
            var sortBy = (p.SortBy ?? "id").ToLower();
            var order = (p.Order ?? "asc").ToLower();

            query = ApplySorting(query, sortBy, order);

            var total = await query.CountAsync();

            var items = await query
                .Skip((p.Page - 1) * p.PageSize)
                .Take(p.PageSize)
                .ToListAsync();

            return new PagedResult<Servico>
            {
                Items = items,
                Total = total,
                Page = p.Page,
                PageSize = p.PageSize
            };
        }

        // ORDENAÇÃO DINÂMICA
        private IQueryable<Servico> ApplySorting(IQueryable<Servico> query, string sortBy, string order)
        {
            return (sortBy, order) switch
            {
                ("nome", "asc") => query.OrderBy(x => x.Nome),
                ("nome", "desc") => query.OrderByDescending(x => x.Nome),

                ("categoria", "asc") => query.OrderBy(x => x.Categoria),
                ("categoria", "desc") => query.OrderByDescending(x => x.Categoria),

                ("id", "desc") => query.OrderByDescending(x => x.Id),

                _ => query.OrderBy(x => x.Id) // fallback padrão
            };
        }
    }
}
