namespace ProjetoCompAplicada.CSharp.UseCases.Servicos
{
    public class PublicServicosFilter
    {
        public string? Nome { get; set; }
        public string? Categoria { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public double? PrecoMin { get; set; }
        public double? PrecoMax { get; set; }

        public int Page { get; set; } = 0;
        public int Size { get; set; } = 10;

        public string SortBy { get; set; } = "Id";
        public string Direction { get; set; } = "desc";

        public bool? HasImage { get; set; }
    }
}
