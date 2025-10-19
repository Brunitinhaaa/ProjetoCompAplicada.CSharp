using Microsoft.EntityFrameworkCore;
using ProjetoCompAplicada.CSharp.Models;

namespace ProjetoCompAplicada.CSharp.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }
	public DbSet<Servico> Servicos { get; set; }
	public DbSet<Imagem> Imagens { get; set; }
	public DbSet<Pagamento> Pagamentos { get; set; }
}
