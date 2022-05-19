namespace Payslip.Domain.Features.Discounts
{
    public abstract partial class Discount
    {
        public decimal Value { get; set; }
        public string Description { get; protected set; }
    }
}