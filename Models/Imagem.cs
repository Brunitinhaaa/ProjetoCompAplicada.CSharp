using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoCompAplicada.CSharp.Models
{
    [Table("imagens")]
    public class Imagem
    {
        [Key]
        public long Id { get; set; }

        [Column("public_id")]
        public string? PublicId { get; set; }

        [Column("secure_url")]
        public string? SecureUrl { get; set; }

        [Column("format")]
        public string? Format { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("width")]
        public int? Width { get; set; }

        [Column("height")]
        public int? Height { get; set; }

        [Column("servico_id")]
        public long? ServicoId { get; set; }

        [JsonIgnore]
        public Servico? Servico { get; set; }
    }
}
