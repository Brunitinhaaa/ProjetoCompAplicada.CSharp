using Microsoft.AspNetCore.Mvc;
using ProjetoCompAplicada.UseCases.Payments;

namespace ProjetoCompAplicada.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Criar um pagamento
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] PaymentRequest request)
        {
            var payment = _paymentService.Create(request);

            return Ok(new PaymentResponse
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Status = payment.Status,
                Description = payment.Description,
                CreatedAt = payment.CreatedAt
            });
        }

        /// <summary>
        /// Listar todos os pagamentos
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_paymentService.GetAll());
        }

        /// <summary>
        /// Buscar pagamento por ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var payment = _paymentService.GetById(id);
            if (payment == null)
                return NotFound("Pagamento não encontrado");

            return Ok(payment);
        }
    }
}
