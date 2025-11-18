using Microsoft.AspNetCore.Mvc;
using ProjetoCompAplicada.CSharp.Models;
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
        public async Task<IActionResult> Get([FromQuery] PublicServicosFilter filter)
        {
            var result = await _servicoPublicQueryService.GetServicosAsync(filter);

            return Ok(ResponseBase<object>.Ok(result));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var servico = await _servicoPublicQueryService.GetServicoByIdAsync(id);

            if (servico == null)
            {
                return NotFound(ResponseBase<object>.Fail(
                    new[] { "Serviço não encontrado." },
                    "Recurso não encontrado"
                ));
            }

            return Ok(ResponseBase<object>.Ok(servico));
        }

        [HttpGet("filter-options")]
        public async Task<IActionResult> GetFilterOptions()
        {
            var result = await _servicoPublicQueryService.GetFilterOptionsAsync();
            return Ok(ResponseBase<FilterOptionsResponse>.Ok(result));
        }

    }
}
