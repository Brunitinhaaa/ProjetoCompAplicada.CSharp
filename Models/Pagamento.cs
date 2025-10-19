using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCompAplicada.CSharp.Models;

[Table("pagamentos")]
public class Pagamento
{
    [Key]
    public long Id { get; set; }

    [Column("mercado_pago_id")]
    public string? MercadoPagoId { get; set; }

    [Column("init_point")]
    public string? InitPoint { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public double? UnitPrice { get; set; }
    public string? Status { get; set; }

    [Column("date_of_expiration")]
    public DateTime? DateOfExpiration { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Column("user_id")]
    public long UserId { get; set; }
}
