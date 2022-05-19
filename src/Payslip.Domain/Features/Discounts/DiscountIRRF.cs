namespace Payslip.Domain.Features.Discounts
{
    public class DiscountIRRF : Discount
    {
        public decimal Aliquot { get; set; }

        public DiscountIRRF(decimal grossSalary)
        {
            Description = "IRRF";
            SetAliquot(grossSalary);
            SetDiscountRoof(grossSalary);
        }

        private void SetAliquot(decimal grossSalary)
        {
            if (grossSalary <= 1903.98m)
            {
                Aliquot = 0;
            }
            else if (grossSalary <= 2826.65m)
            {
                Aliquot = 7.5m;
            }
            else if (grossSalary <= 3751.05m)
            {
                Aliquot = 15m;
            }
            else if (grossSalary <= 4664.68m)
            {
                Aliquot = 22.5m;
            }
            else
            {
                Aliquot = 27.5m;
            }
        }

        private void SetDiscountRoof(decimal grossSalary)
        {
            Value = grossSalary * Aliquot / 100;

            if (Value > 142.8m && Aliquot == 7.5m)
                Value = 142.8m;

            if (Value > 354.8m && Aliquot == 15.0m)
                Value = 354.8m;

            if (Value > 636.13m && Aliquot == 22.5m)
                Value = 636.13m;

            if (Value > 869.36m && Aliquot == 27.5m)
                Value = 869.36m;
        }
    }
}