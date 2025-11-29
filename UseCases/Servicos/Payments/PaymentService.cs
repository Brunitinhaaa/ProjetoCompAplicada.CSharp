namespace ProjetoCompAplicada.UseCases.Payments

{
    public class PaymentService
    {
        private readonly List<PaymentResponse> _payments = new();

        public PaymentResponse Create(PaymentRequest request)
        {
            var payment = new PaymentResponse
            {
                Id = Guid.NewGuid(),
                Amount = request.Amount,
                Description = request.Description,
                Status = "Aprovado",
                CreatedAt = DateTime.UtcNow
            };

            _payments.Add(payment);
            return payment;
        }

        public IEnumerable<PaymentResponse> GetAll()
        {
            return _payments;
        }

        public PaymentResponse? GetById(Guid id)
        {
            return _payments.FirstOrDefault(x => x.Id == id);
        }
    }
}
