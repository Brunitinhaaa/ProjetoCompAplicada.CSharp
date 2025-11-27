using Microsoft.Extensions.DependencyInjection;
using ProjetoCompAplicada.CSharp.UseCases.Servicos;

namespace ProjetoCompAplicada.CSharp.Configurations
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IServicoPublicQueryService, ServicoPublicQueryService>();

			return services;
		}
	}
}
