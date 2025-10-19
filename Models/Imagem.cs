using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCompAplicada.CSharp.Models;

[Table("imagens")]
public class Imagem
{
    [Key]
    public long Id { get; set; }

    public string? PublicId { get; set; }
    public string? SecureUrl { get; set; }
    public string? Format { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }

    [Column("servico_id")]
    public long? ServicoId { get; set; }

    public Servico? Servico { get; set; }
}
