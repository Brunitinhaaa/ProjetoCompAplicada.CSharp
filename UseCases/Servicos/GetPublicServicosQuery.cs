using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjetoCompAplicada.CSharp.Data;
using ProjetoCompAplicada.CSharp.Models;

namespace ProjetoCompAplicada.CSharp.UseCases.Servicos
{
    public interface IServicoPublicQueryService
    {
        Task<object> GetServicosAsync(PublicServicosFilter filter);
        Task<Servico?> GetServicoByIdAsync(long id);

        Task<FilterOptionsResponse> GetFilterOptionsAsync();
    }

    public class ServicoPublicQueryService : IServicoPublicQueryService
    {
        private readonly AppDbContext _context;

        public ServicoPublicQueryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetServicosAsync(PublicServicosFilter filter)
        {
            var query = _context.Servicos
                .Include(s => s.Imagem)
                .Where(s => s.Ativo);

            if (filter.HasImage.HasValue)
            {
                if (filter.HasImage.Value)
                {
                    query = query.Where(s => s.Imagem != null);
                }
                else
                {
                    query = query.Where(s => s.Imagem == null);
                }
            }

            if (!string.IsNullOrWhiteSpace(filter.Cidade))
            {
                var cidade = filter.Cidade.Trim();
                query = query.Where(s => s.Cidade != null && s.Cidade.Contains(cidade));
            }

            if (!string.IsNullOrWhiteSpace(filter.Uf))
            {
                var uf = filter.Uf.Trim();
                query = query.Where(s => s.Uf != null && s.Uf.Contains(uf));
            }

            if (filter.PrecoMin.HasValue)
                query = query.Where(s => s.Preco >= filter.PrecoMin.Value);

            if (filter.PrecoMax.HasValue)
                query = query.Where(s => s.Preco <= filter.PrecoMax.Value);

            var lista = await query.ToListAsync();

            if (!string.IsNullOrWhiteSpace(filter.Nome))
            {
                var buscaNome = Normalize(filter.Nome);
                lista = lista
                    .Where(s => !string.IsNullOrEmpty(s.Nome)
                                && Normalize(s.Nome).Contains(buscaNome))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(filter.Categoria))
            {
                var buscaCategoria = Normalize(filter.Categoria);
                lista = lista
                    .Where(s => !string.IsNullOrEmpty(s.Categoria)
                                && Normalize(s.Categoria).Contains(buscaCategoria))
                    .ToList();
            }

            var sortBy = string.IsNullOrWhiteSpace(filter.SortBy) ? "Id" : filter.SortBy;
            var direction = (filter.Direction ?? "desc").ToLower();

            lista = direction == "asc"
                ? lista.OrderBy(s => GetSortValue(s, sortBy)).ToList()
                : lista.OrderByDescending(s => GetSortValue(s, sortBy)).ToList();

            var total = lista.Count;

            var page = filter.Page < 0 ? 0 : filter.Page;
            var size = filter.Size <= 0 ? 10 : filter.Size;

            var data = lista
                .Skip(page * size)
                .Take(size)
                .Select(s => new
                {
                    s.Id,
                    s.Nome,
                    s.Categoria,
                    s.Preco,
                    s.Cidade,
                    s.Uf,
                    ImagemUrl = s.Imagem != null ? s.Imagem.SecureUrl : null
                })
                .ToList();

            return new
            {
                page,
                size,
                total,
                data
            };
        }

        public async Task<Servico?> GetServicoByIdAsync(long id)
        {
            return await _context.Servicos
                .Include(s => s.Imagem)
                .FirstOrDefaultAsync(s => s.Id == id && s.Ativo);
        }

        private static string Normalize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var normalized = value.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalized)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(c);
                if (cat != UnicodeCategory.NonSpacingMark)
                    sb.Append(char.ToLowerInvariant(c));
            }

            return sb.ToString();
        }

        private static object? GetSortValue(Servico s, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "id": return s.Id;
                case "nome": return s.Nome;
                case "preco": return s.Preco;
                case "cidade": return s.Cidade;
                case "categoria": return s.Categoria;
                default: return s.Id;
            }
        }

        public async Task<FilterOptionsResponse> GetFilterOptionsAsync()
        {
            var query = _context.Servicos
                .AsNoTracking()
                .Where(s => s.Ativo);

            var categories = await query
                .Select(s => s.Categoria!)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            var cities = await query
                .Select(s => s.Cidade!)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            var states = await query
                .Select(s => s.Uf!)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            return new FilterOptionsResponse
            {
                Categories = categories,
                Cities = cities,
                States = states
            };
        }
    }
}
