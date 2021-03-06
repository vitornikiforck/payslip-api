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
        private const string _descriptionINSS = "INSS";
        private const string _descriptionIRRF = "IRRF";
        private const string _descriptionFGTS = "FGTS";
        private const string _descriptionHealthPlan = "Plano de Saúde";
        private const string _descriptionDentalPlan = "Plano Dental";
        private const string _descriptionTransportationVoucher = "Vale Transporte";

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

        [Test]
        public void TotalDiscountValueNegative_ShouldBeNegative_ForAnyTotalDiscountValue()
        {
            //Arrange
            decimal grossSalary = 1045.0m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.TotalDiscountValueNegative.Should().BeNegative();
        }

        [Test]
        public void NetSalary_ShouldBeCalculateCorrectly_ForAnyTotalDiscountValue()
        {
            //Arrange
            decimal grossSalary = 1045.0m;
            decimal discountINSS = new DiscountINSS(grossSalary).Value;
            decimal discountFGTS = new DiscountFGTS(grossSalary).Value;
            decimal totalDiscount = discountINSS + discountFGTS;
            decimal expectedNetSalary = grossSalary - totalDiscount;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.NetSalary.Should().Be(expectedNetSalary);
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndFGTSDiscount()
        {
            //Arrange
            decimal grossSalary = 1045.0m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndIRRFAndFGTSDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndFGTSAndHealthPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1045.0m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndIRRFAndFGTSAndHealthPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndFGTSAndDentalPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1045.0m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.DentalPlan).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndIRRFAndFGTSAndDentalPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.DentalPlan).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndFGTSAndTransportationVoucherDiscount()
        {
            //Arrange
            decimal grossSalary = 1500;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.TransportantionVoucher).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndIRRFAndFGTSAndTransportationVoucherDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.TransportantionVoucher).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndFGTSAndHealthDentalPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1045;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(true);
            _employee.Setup(e => e.DentalPlan).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndFGTSAndHealthPlanTransportationVoucherDiscount()
        {
            //Arrange
            decimal grossSalary = 1500;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(true);
            _employee.Setup(e => e.TransportantionVoucher).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndFGTSAndDentalPlanTransportationVoucherDiscount()
        {
            //Arrange
            decimal grossSalary = 1500;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.DentalPlan).Returns(true);
            _employee.Setup(e => e.TransportantionVoucher).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Should().BeNull();
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndIRRFAndFGTSAndHealthDentalPlanDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(true);
            _employee.Setup(e => e.DentalPlan).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndIRRFAndFGTSAndHealthPlanTransportationVoucherDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(true);
            _employee.Setup(e => e.TransportantionVoucher).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingINSSAndIRRFAndFGTSAndDentalPlanTransportationVoucherDiscount()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(true);
            _employee.Setup(e => e.TransportantionVoucher).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Should().BeNull();
        }

        [Test]
        public void Launches_ShouldBeGenerateCorrectly_HavingAllDiscounts()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);
            _employee.Setup(e => e.HealthPlan).Returns(true);
            _employee.Setup(e => e.DentalPlan).Returns(true);
            _employee.Setup(e => e.TransportantionVoucher).Returns(true);

            //Action
            var paymentslip = new Paymentslip(_employee.Object);

            //Assert
            paymentslip.Launches.Find(l => l.Description == _descriptionINSS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionFGTS).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionIRRF).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionTransportationVoucher).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionHealthPlan).Value.Should().BeGreaterThan(0);
            paymentslip.Launches.Find(l => l.Description == _descriptionDentalPlan).Value.Should().BeGreaterThan(0);
        }
    }
}