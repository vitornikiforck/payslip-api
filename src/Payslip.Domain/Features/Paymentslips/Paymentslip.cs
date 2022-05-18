﻿using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;
using Payslip.Domain.Features.Launches;

namespace Payslip.Domain.Features.Paymentslips
{
    public class Paymentslip
    {
        private decimal _discountINSS;
        private decimal _discountIRRF;
        private decimal _discountFGTS;
        private decimal _discountHealthPlan;
        private decimal _discountDentalPlan;
        private decimal _discountTransportationVoucher;
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
            _discountINSS = new DiscountINSS(Employee.GrossSalary).Value;
            _discountIRRF = new DiscountIRRF(Employee.GrossSalary).Value;
            _discountFGTS = new DiscountFGTS(Employee.GrossSalary).Value;
            ApplyDiscounts();
            NetSalary = GetNetSalary();
            GenerateLaunches();
            TotalDiscountValueNegative = Decimal.Negate(TotalDiscountValue);
        }

        private void ApplyDiscounts()
        {
            TotalDiscountValue = _discountINSS + _discountIRRF + _discountFGTS;
            TotalDiscountValue += new DiscountHealthPlan(Employee.HealthPlan).Value;
            TotalDiscountValue += new DiscountDentalPlan(Employee.DentalPlan).Value;
            TotalDiscountValue += new DiscountTransportationVoucher(Employee.GrossSalary, Employee.TransportantionVoucher).Value;
        }

        private decimal GetNetSalary() => Employee.GrossSalary - TotalDiscountValue;

        private void GenerateLaunches()
        {
            Launches.Add(new Launch(LaunchType.Discount, _discountINSS, "INSS"));
            Launches.Add(new Launch(LaunchType.Discount, _discountIRRF, "IRPF"));
            Launches.Add(new Launch(LaunchType.Discount, _discountFGTS, "FGTS"));
            Launches.Add(new Launch(LaunchType.Discount, _discountHealthPlan, "Plano de Saúde"));
            Launches.Add(new Launch(LaunchType.Discount, _discountDentalPlan, "Plano Dental"));
            Launches.Add(new Launch(LaunchType.Discount, _discountTransportationVoucher, "Vale Transporte"));
        }
    }
}