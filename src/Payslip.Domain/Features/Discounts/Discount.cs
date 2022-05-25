namespace Payslip.Domain.Features.Discounts
{
    /// <summary>
    /// Classe abstrata de desconto da qual os tipos de desconto herdam
    /// </summary>
    public abstract class Discount
    {
        public decimal Value { get; protected set; }
        public string Description { get; protected set; }
    }
}