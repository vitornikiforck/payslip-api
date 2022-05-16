namespace Payslip.Domain.Features.Discounts
{
    public class DiscountIRPF : Discount
    {
        protected override decimal Calculate(decimal grossSalary)
        {
            decimal aliquot = GetAliquot(grossSalary);

            decimal discount = grossSalary * aliquot / 100;

            if (discount > 142.8m && aliquot == 7.5m)
                discount = 142.8m;

            if (discount > 354.8m && aliquot == 15.0m)
                discount = 354.8m;

            if (discount > 636.13m && aliquot == 22.5m)
                discount = 636.13m;

            if (discount > 869.36m && aliquot == 27.5m)
                discount = 869.36m;

            return discount;
        }

        private decimal GetAliquot(decimal grossSalary)
        {
            decimal aliquot = 0m;

            if (grossSalary <= 1903.98m)
            {
                aliquot = 0;
            }
            else if (grossSalary <= 2826.65m)
            {
                aliquot = 7.5m;
            }
            else if (grossSalary <= 4664.68m)
            {
                aliquot = 22;
            }
            else
            {
                aliquot = 27.5m;
            }

            return aliquot;
        }
    }

}
