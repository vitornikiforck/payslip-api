using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;
using Payslip.Domain.Features.Launches;

namespace Payslip.Domain.Features.Paymentslips
{
    public class Paymentslip
    {
        private DiscountINSS _discountINSS;
        private DiscountIRRF _discountIRRF;
        private DiscountFGTS _discountFGTS;
        private DiscountHealthPlan _discountHealthPlan;
        private DiscountDentalPlan _discountDentalPlan;
        private DiscountTransportationVoucher _discountTransportationVoucher;
        public int ReferenceMonth { get; private set; }
        public List<Launch> Launches { get; private set; }
        public decimal GrossSalary { get; private set; }
        public decimal TotalDiscountValue { get; private set; }
        public decimal TotalDiscountValueNegative { get; private set; }
        public decimal NetSalary { get; private set; }
        public Employee Employee { get; private set; }

        public Paymentslip(Employee employee)
        {
            Launches = new List<Launch>();
            ReferenceMonth = DateTime.UtcNow.Month;
            Employee = employee;
            TotalDiscountValue = GetTotalDiscountValue();
            TotalDiscountValueNegative = GetTotalDiscountNegativeValue();
            NetSalary = GetNetSalary();
            GenerateLaunches();
        }

        private decimal GetTotalDiscountValue()
        {
            _discountINSS = new DiscountINSS(Employee.GrossSalary);
            _discountIRRF = new DiscountIRRF(Employee.GrossSalary);
            _discountFGTS = new DiscountFGTS(Employee.GrossSalary);
            _discountHealthPlan = new DiscountHealthPlan(Employee.HealthPlan);
            _discountDentalPlan = new DiscountDentalPlan(Employee.DentalPlan);
            _discountTransportationVoucher = new DiscountTransportationVoucher(Employee.GrossSalary, Employee.TransportantionVoucher);

            return _discountINSS.Value + _discountIRRF.Value + _discountFGTS.Value + _discountHealthPlan.Value
                                       + _discountDentalPlan.Value + _discountTransportationVoucher.Value;
        }

        private decimal GetTotalDiscountNegativeValue() => Decimal.Negate(TotalDiscountValue);
        private decimal GetNetSalary() => Employee.GrossSalary - TotalDiscountValue;

        private void GenerateLaunches()
        {
            Launches.Add(new Launch(LaunchType.Discount, _discountINSS));
            Launches.Add(new Launch(LaunchType.Discount, _discountIRRF));
            Launches.Add(new Launch(LaunchType.Discount, _discountFGTS));
            Launches.Add(new Launch(LaunchType.Discount, _discountHealthPlan));
            Launches.Add(new Launch(LaunchType.Discount, _discountDentalPlan));
            Launches.Add(new Launch(LaunchType.Discount, _discountTransportationVoucher));
        }
    }
}