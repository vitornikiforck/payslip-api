namespace Payslip.Domain.Features.Discounts
{
    public class DiscountINSS : Discount
    {
        public override void Calculate(decimal grossSalary) 
        {
            SetAliquot(grossSalary);
            Value = grossSalary * Aliquot / 100; 
        }

        private void SetAliquot(decimal grossSalary)
        {
            if (grossSalary <= 1045.00m)
            {
                Aliquot = 7.5m;
            }
            else if (grossSalary <= 2089.60m)
            {
                Aliquot = 9.0m;
            }
            else if (grossSalary <= 3134.40m)
            {
                Aliquot = 12.0m;
            }
            else
            {
                Aliquot = 14.0m;
            }
        }
    }
}