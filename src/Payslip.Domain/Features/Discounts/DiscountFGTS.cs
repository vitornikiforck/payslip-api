namespace Payslip.Domain.Features.Discounts
{
    public class DiscountFGTS : Discount
    {
        public DiscountFGTS(decimal grossSalary)
        {
            Aliquot = 8;
            Value = grossSalary * Aliquot / 100;
        }
    }
}