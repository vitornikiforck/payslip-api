namespace Payslip.Domain.Features.Discounts
{
    public class DiscountINSS : Discount
    {
        protected override decimal Calculate(decimal grossSalary) => grossSalary * GetAliquot(grossSalary) / 100;

        private decimal GetAliquot(decimal grossSalary)
        {
            decimal aliquot = 0.0m;

            if (grossSalary <= 1045.00m)
            {
                aliquot = 7.5m;
            }
            else if (grossSalary <= 2089.60m)
            {
                aliquot = 9.0m;
            }
            else if (grossSalary <= 3134.40m)
            {
                aliquot = 12.0m;
            }
            else
            {
                aliquot = 14.0m;
            }

            return aliquot;
        }
    }
}
