using FluentAssertions;
using Moq;
using NUnit.Framework;
using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;

namespace Payslip.Domain.Tests.Features.Discounts
{
    [TestFixture]
    [Category("Payslip.Domain.Tests.Discounts")]
    public class DiscountFGTSTest
    {
        private Mock<Employee> _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Mock<Employee>();
        }

        [Test]
        public void DiscountFGTS_ShoudReturnCorrectValue_ForAnyGrossSalary()
        {
            //Arrange
            decimal grossSalary = 1500;
            decimal expectedDiscountFGTSValue = grossSalary * 8 / 100;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountFGTS = new DiscountFGTS(_employee.Object.GrossSalary);

            //Assert
            discountFGTS.Value.Should().Be(expectedDiscountFGTSValue);
        }
    }
}
