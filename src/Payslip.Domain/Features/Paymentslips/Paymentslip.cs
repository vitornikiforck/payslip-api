using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;
using Payslip.Domain.Features.Launches;

namespace Payslip.Domain.Features.Paymentslips
{
    /// <summary>
    /// Representa um extrato de contracheque
    /// </summary>
    public class Paymentslip
    {
        private DiscountINSS _discountINSS;
        private DiscountIRRF _discountIRRF;
        private DiscountFGTS _discountFGTS;
        private DiscountHealthPlan _discountHealthPlan;
        private DiscountDentalPlan _discountDentalPlan;
        private DiscountTransportationVoucher _discountTransportationVoucher;
        public int ReferenceMonth { get; private set; }
        /// <summary>
        /// Lista de Lançamentos
        /// </summary>
        public List<Launch> Launches { get; private set; }
        public decimal GrossSalary { get; private set; }
        public decimal TotalDiscountValue { get; private set; }
        public decimal TotalDiscountValueNegative { get; private set; }
        /// <summary>
        /// Salário Líquido
        /// </summary>
        public decimal NetSalary { get; private set; }
        public Employee Employee { get; private set; }

        public Paymentslip(Employee employee)
        {
            Launches = new List<Launch>();
            ReferenceMonth = DateTime.UtcNow.Month;
            Employee = employee;
            GrossSalary = employee.GrossSalary;
            TotalDiscountValue = GetTotalDiscountValue();
            TotalDiscountValueNegative = GetTotalDiscountNegativeValue();
            NetSalary = GetNetSalary();
            GenerateLaunches();
        }

        /// <summary>
        /// Retorna o valor total de descontos do funcionário
        /// </summary>
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

        /// <summary>
        /// Retorna o valor negativo do total de descontos
        /// </summary>
        private decimal GetTotalDiscountNegativeValue() => Decimal.Negate(TotalDiscountValue);
        /// <summary>
        /// Retorna o salário líquido do funcionário
        /// </summary>
        private decimal GetNetSalary() => Employee.GrossSalary - TotalDiscountValue;

        /// <summary>
        /// Cria a lista de lançamentos com os devidos descontos do funcionário
        /// </summary>
        private void GenerateLaunches()
        {
            Launches.Add(new Launch(LaunchType.Discount, _discountINSS));
            Launches.Add(new Launch(LaunchType.Discount, _discountFGTS));
            if (_discountIRRF.Value > 0) Launches.Add(new Launch(LaunchType.Discount, _discountIRRF));
            if (_discountHealthPlan.Value > 0) Launches.Add(new Launch(LaunchType.Discount, _discountHealthPlan));
            if(_discountDentalPlan.Value > 0) Launches.Add(new Launch(LaunchType.Discount, _discountDentalPlan));
            if(_discountTransportationVoucher.Value > 0) Launches.Add(new Launch(LaunchType.Discount, _discountTransportationVoucher));
        }
    }
}