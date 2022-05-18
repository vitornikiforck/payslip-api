namespace Payslip.Domain.Features.Discounts
{
    public class DiscountFGTS : Discount
    {
        public DiscountFGTS(decimal grossSalary)
        {
            Value = grossSalary * 8 / 100;
        }
    }
}