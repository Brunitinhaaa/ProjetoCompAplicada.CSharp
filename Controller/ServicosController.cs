using Microsoft.AspNetCore.Mvc;
using ProjetoCompAplicada.CSharp.UseCases.Servicos;

namespace ProjetoCompAplicada.CSharp.Controllers
{
    [ApiController]
    [Route("api/public/[controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoPublicQueryService _servicoPublicQueryService;

        public ServicosController(IServicoPublicQueryService servicoPublicQueryService)
        {
            _servicoPublicQueryService = servicoPublicQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicos([FromQuery] PublicServicosFilter filter)
        {
            var result = await _servicoPublicQueryService.GetServicosAsync(filter);
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var servico = await _servicoPublicQueryService.GetServicoByIdAsync(id);

            if (servico == null)
                return NotFound(new { message = "Serviço não encontrado." });

            return Ok(servico);
        }
    }
}
