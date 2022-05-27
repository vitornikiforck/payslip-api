namespace Payslip.Domain.Features.Discounts
{
    public class DiscountFGTS : Discount
    {
        public DiscountFGTS(decimal grossSalary)
        {
            Description = "FGTS";
            Value = grossSalary * 8 / 100;
        }
    }
}