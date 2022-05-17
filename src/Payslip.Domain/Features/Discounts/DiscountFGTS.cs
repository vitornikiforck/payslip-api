namespace Payslip.Domain.Features.Discounts
{
    public class DiscountFGTS : Discount
    {
        public override void Calculate(decimal grossSalary)
        {
            Aliquot = 8;
            Value = grossSalary * Aliquot / 100;
        }
    }
}