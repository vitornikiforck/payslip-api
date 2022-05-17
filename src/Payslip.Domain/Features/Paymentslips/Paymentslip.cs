using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;
using Payslip.Domain.Features.Launches;

namespace Payslip.Domain.Features.Paymentslips
{
    public class Paymentslip
    {
        private decimal _discountINSS { get; set; }
        private decimal _discountIRPF { get; set; }
        private decimal _discountFGTS { get; set; }
        private decimal _discountHealthPlan { get; set; }
        private decimal _discountDentalPlan { get; set; }
        private decimal _discountTransportationVoucher { get; set; }
        public int ReferenceMonth { get; private set; }
        public List<Launch> Launches { get; private set; }
        public decimal GrossSalary { get; private set; }
        public decimal TotalDiscountValue { get; private set; }
        public decimal NetSalary { get; private set; }
        public Employee Employee { get; private set; }

        public Paymentslip(Employee employee)
        {
            Launches = new List<Launch>();
            ReferenceMonth = DateTime.UtcNow.Month;
            Employee = employee;
            ApplyDiscounts();
            SetNetSalary();
            GenerateLaunches();
        }

        private void ApplyDiscounts()
        {
            var discountINSS = new DiscountINSS();
            discountINSS.Calculate(Employee.GrossSalary);

            var discountIRPF = new DiscountIRPF();
            discountIRPF.Calculate(Employee.GrossSalary);

            var discountFGTS = new DiscountFGTS();
            discountFGTS.Calculate(Employee.GrossSalary);

            _discountINSS = discountINSS.Value;
            _discountIRPF = discountIRPF.Value;
            _discountFGTS = discountFGTS.Value;

            TotalDiscountValue = discountINSS.Value + discountIRPF.Value + discountFGTS.Value;

            if (Employee.HealthPlan)
            {
                _discountHealthPlan = 10;
                TotalDiscountValue += _discountHealthPlan;
            }

            if (Employee.DentalPlan)
            {
                _discountDentalPlan = 5;
                TotalDiscountValue += _discountDentalPlan;
            }

            if (Employee.TransportantionVoucher && Employee.GrossSalary >= 1500)
            {
                _discountTransportationVoucher = Employee.GrossSalary * 6 / 100;
                TotalDiscountValue += _discountTransportationVoucher;
            }
        }

        private void SetNetSalary()
        {
            NetSalary = Employee.GrossSalary - TotalDiscountValue;
        }

        private void GenerateLaunches()
        {
            Launches.Add(new Launch()
            {
                Type = LaunchType.Discount,
                Description = "INSS",
                Value = _discountINSS
            });

            Launches.Add(new Launch()
            {
                Type = LaunchType.Discount,
                Description = "IRPF",
                Value = _discountIRPF
            });

            Launches.Add(new Launch()
            {
                Type = LaunchType.Discount,
                Description = "FGTS",
                Value = _discountFGTS
            });

            Launches.Add(new Launch()
            {
                Type = LaunchType.Discount,
                Description = "Plano de Saúde",
                Value = _discountHealthPlan
            });

            Launches.Add(new Launch()
            {
                Type = LaunchType.Discount,
                Description = "Plano Dental",
                Value = _discountDentalPlan
            });

            Launches.Add(new Launch()
            {
                Type = LaunchType.Discount,
                Description = "Vale Transporte",
                Value = _discountTransportationVoucher
            });
        }
    }
}