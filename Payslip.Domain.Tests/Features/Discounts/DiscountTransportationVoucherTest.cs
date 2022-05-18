using FluentAssertions;
using Moq;
using NUnit.Framework;
using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;

namespace Payslip.Domain.Tests.Features.Discounts
{
    public class DiscountTransportationVoucherTest
    {
        private Mock<Employee> _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Mock<Employee>();
        }

        [Test]
        public void DiscountTransportationVoucher_ShoudReturnCorrectValue_WhenEmployeeHasTransportationVoucherAndGrossSalaryBiggerThan1499()
        {
            //Arrange
            decimal employeeGrossSalary = 1500;
            bool hasTransportationVoucher = true;
            decimal expectedTransportationVoucherValue = employeeGrossSalary * 6 / 100;
            _employee.Setup(e => e.GrossSalary).Returns(employeeGrossSalary);
            _employee.Setup(e => e.TransportantionVoucher).Returns(hasTransportationVoucher);
            var employee = _employee.Object;

            //Action
            var transportationVoucherDiscount = new DiscountTransportationVoucher(employee.GrossSalary, employee.TransportantionVoucher);

            //Assert
            transportationVoucherDiscount.Value.Should().Be(expectedTransportationVoucherValue);
        }

        [Test]
        public void DiscountTransportationVoucher_ShoudReturnCorrectValue_WhenEmployeeDoNotHaveTransportationVoucher()
        {
            //Arrange
            decimal employeeGrossSalary = 1500;
            bool hasTransportationVoucher = false;
            decimal expectedTransportationVoucherValue = 0;
            _employee.Setup(e => e.GrossSalary).Returns(employeeGrossSalary);
            _employee.Setup(e => e.TransportantionVoucher).Returns(hasTransportationVoucher);
            var employee = _employee.Object;

            //Action
            var transportationVoucherDiscount = new DiscountTransportationVoucher(employee.GrossSalary, employee.TransportantionVoucher);

            //Assert
            transportationVoucherDiscount.Value.Should().Be(expectedTransportationVoucherValue);
        }

        [Test]
        public void DiscountTransportationVoucher_ShoudReturnCorrectValue_WhenEmployeeHasTransportationVoucherAndGrossSalaryLessThan1500()
        {
            //Arrange
            decimal employeeGrossSalary = 1499;
            bool hasTransportationVoucher = true;
            decimal expectedTransportationVoucherValue = 0;
            _employee.Setup(e => e.GrossSalary).Returns(employeeGrossSalary);
            _employee.Setup(e => e.TransportantionVoucher).Returns(hasTransportationVoucher);
            var employee = _employee.Object;

            //Action
            var transportationVoucherDiscount = new DiscountTransportationVoucher(employee.GrossSalary, employee.TransportantionVoucher);

            //Assert
            transportationVoucherDiscount.Value.Should().Be(expectedTransportationVoucherValue);
        }


        [Test]
        public void DiscountTransportationVoucher_ShoudReturnCorrectValue_WhenEmployeeDoNotHaveTransportationVoucherAndGrossSalaryLessThan1500()
        {
            //Arrange
            decimal employeeGrossSalary = 1499;
            bool hasTransportationVoucher = false;
            decimal expectedTransportationVoucherValue = 0;
            _employee.Setup(e => e.GrossSalary).Returns(employeeGrossSalary);
            _employee.Setup(e => e.TransportantionVoucher).Returns(hasTransportationVoucher);
            var employee = _employee.Object;

            //Action
            var transportationVoucherDiscount = new DiscountTransportationVoucher(employee.GrossSalary, employee.TransportantionVoucher);

            //Assert
            transportationVoucherDiscount.Value.Should().Be(expectedTransportationVoucherValue);
        }
    }
}