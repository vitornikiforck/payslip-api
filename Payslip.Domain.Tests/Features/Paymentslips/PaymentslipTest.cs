using FluentAssertions;
using Moq;
using NUnit.Framework;
using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;
using Payslip.Domain.Features.Paymentslips;
using System;

namespace Payslip.Domain.Tests.Features.Paymentslips
{
    [TestFixture]
    [Category("Payslip.Domain.Tests.Paymentslips")]
    public class PaymentslipTest
    {
        private Mock<Employee> _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Mock<Employee>();
        }

        [Test]
        public void ReferenceMonth_ShouldBeCurrentMonth()
        {
            //Arrange
            var currentMonth = DateTime.UtcNow.Month;

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.ReferenceMonth.Should().Be(currentMonth);
        }

        [Test]
        public void TotalDiscountValue_ShouldBeCalculateCorrectly_HavingINSSAndFGTSAndHealthPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1045.0m;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            bool hasHealthPlan = true;
            decimal healthPlanDiscountValue = new DiscountHealthPlan(hasHealthPlan).Value;
            decimal expectedTotalDiscount = discountINSS + discountFGTS + healthPlanDiscountValue;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(hasHealthPlan);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValue.Should().Be(expectedTotalDiscount);
        }

        [Test]
        public void TotalDiscountValue_ShouldBeCalculateCorrectly_HavingINSSAndIRRFAndFGTSAndHealthPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountIRRF = new DiscountIRRF(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            bool hasHealthPlan = true;
            decimal healthPlanDiscountValue = new DiscountHealthPlan(hasHealthPlan).Value;
            decimal expectedTotalDiscount = discountINSS + discountIRRF + discountFGTS + healthPlanDiscountValue;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(hasHealthPlan);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValue.Should().Be(expectedTotalDiscount);
        }

        [Test]
        public void TotalDiscountValue_ShouldBeCalculateCorrectly_HavingINSSAndFGTSAndDentalPlanAndDiscount()
        {
            //Arrange
            decimal grossSalary = 1045.0m;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            bool hasDentalPlan = true;
            decimal dentalPlanDiscountValue = new DiscountDentalPlan(hasDentalPlan).Value;
            decimal expectedTotalDiscount = discountINSS + discountFGTS + dentalPlanDiscountValue;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.DentalPlan).Returns(hasDentalPlan);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValue.Should().Be(expectedTotalDiscount);
        }

        [Test]
        public void TotalDiscountValue_ShouldBeCalculateCorrectly_HavingINSSAndIRRFAndFGTSAndDentalPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountIRRF = new DiscountIRRF(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            bool hasDentalPlan = true;
            decimal dentalPlanDiscountValue = new DiscountDentalPlan(hasDentalPlan).Value;
            decimal expectedTotalDiscount = discountINSS + discountIRRF + discountFGTS + dentalPlanDiscountValue;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.DentalPlan).Returns(hasDentalPlan);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValue.Should().Be(expectedTotalDiscount);
        }

        [Test]
        public void TotalDiscountValue_ShouldBeCalculateCorrectly_HavingINSSAndFGTSAndTransportationVoucherDiscount()
        {
            //Arrange
            decimal grossSalary = 1500;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            bool hasTransportationVoucher = true;
            decimal transportantionVoucherValue = new DiscountTransportationVoucher(grossSalary, hasTransportationVoucher).Value;
            decimal expectedTotalDiscount = discountINSS + discountFGTS + transportantionVoucherValue;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.TransportantionVoucher).Returns(hasTransportationVoucher);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValue.Should().Be(expectedTotalDiscount);
        }

        [Test]
        public void TotalDiscountValue_ShouldBeCalculateCorrectly_HavingINSSAndIRRFAndFGTSAndTransportationVoucherDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountIRRF = new DiscountIRRF(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            bool hasTransportationVoucher = true;
            decimal transportantionVoucherValue = new DiscountTransportationVoucher(grossSalary, hasTransportationVoucher).Value;
            decimal expectedTotalDiscount = discountINSS + discountIRRF + discountFGTS + transportantionVoucherValue;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.TransportantionVoucher).Returns(hasTransportationVoucher);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValue.Should().Be(expectedTotalDiscount);
        }

        [Test]
        public void TotalDiscountValue_ShouldBeCalculateCorrectly_HavingINSSAndIRRFAndFGTSDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountIRRF = new DiscountIRRF(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            decimal expectedTotalDiscount = discountINSS + discountIRRF + discountFGTS;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValue.Should().Be(expectedTotalDiscount);
        }

        [Test]
        public void TotalDiscountValue_ShouldBeCalculateCorrectly_HavingINSSAndFGTSAndDiscount()
        {
            //Arrange
            decimal grossSalary = 1045.0m;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            decimal expectedTotalDiscount = discountINSS + discountFGTS;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValue.Should().Be(expectedTotalDiscount);
        }
    }
}
