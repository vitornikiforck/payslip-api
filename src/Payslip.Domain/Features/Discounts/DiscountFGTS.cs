namespace Payslip.Domain.Features.Discounts
{
    public class DiscountFGTS : Discount
    {
        const int fgtsPercentageValue = 8;
        protected override decimal Calculate(decimal grossSalary) => grossSalary * fgtsPercentageValue / 100;
    }
}
