namespace ProjetoCompAplicada.UseCases.Payments

{
    public class PaymentResponse
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
