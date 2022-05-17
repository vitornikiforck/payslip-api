namespace Payslip.Domain.Features.Discounts
{
    public abstract partial class Discount
    {
        public decimal Value { get; set; }
        public decimal Aliquot { get; set; }
    }
}