namespace Payslip.Domain.Features.Discounts
{
    public class DiscountTransportationVoucher : Discount
    {
        public DiscountTransportationVoucher(decimal grossSalary, bool hasTransportationVoucher)
        {
            Description = "Vale Transporte";
            if (grossSalary >= 1500 && hasTransportationVoucher)
                Value = grossSalary * 6 / 100;
        }
    }
}
