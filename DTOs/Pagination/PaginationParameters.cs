namespace ProjetoCompAplicada.CSharp.UseCases.Pagination
{
    public class PaginationParameters
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // Ordenação
        public string? SortBy { get; set; } = "id"; // nome da coluna
        public string? Order { get; set; } = "asc"; // asc | desc
    }
}
