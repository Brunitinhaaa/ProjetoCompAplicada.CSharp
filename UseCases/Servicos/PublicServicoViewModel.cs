namespace ProjetoCompAplicada.CSharp.UseCases.Servicos
{
    public class PublicServicoViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; } = default!;
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Categoria { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
