using Payslip.Domain.Features.Launches;

namespace Payslip.Domain.Features.Payslips
{
    public class Payslip
    {
        public int ReferenceMonth { get; private set; }
        public List<Launch> Launches { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal TotalDiscountValue { get; set; }
        public decimal NetSalary { get; set; }

        public Payslip()
        {
            ReferenceMonth = DateTime.UtcNow.Month;
        }
    }
}
