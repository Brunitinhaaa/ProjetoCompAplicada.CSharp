using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCompAplicada.CSharp.Data;
using ProjetoCompAplicada.CSharp.Models;

namespace ProjetoCompAplicada.CSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HealthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            bool dbOk;

            try
            {
                dbOk = await _context.Database.CanConnectAsync();
            }
            catch
            {
                dbOk = false;
            }

            var result = new
            {
                status = "OK",
                database = dbOk ? "OK" : "FAILED"
            };

            if (!dbOk)
            {
                return StatusCode(500, ResponseBase<object>.Fail(
                    new[] { "Banco de dados não está acessível." },
                    "Erro ao verificar o banco de dados"
                ));
            }

            return Ok(ResponseBase<object>.Ok(result));
        }
    }
}
