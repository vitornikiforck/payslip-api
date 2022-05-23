using FluentAssertions;
using Moq;
using NUnit.Framework;
using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;

namespace Payslip.Domain.Tests.Features.Discounts
{
    [TestFixture]
    [Category("Payslip.Domain.Tests.Discounts")]
    public class DiscountINSSTest
    {
        private Mock<Employee> _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Mock<Employee>();
        }

        [Test]
        public void DiscountINSS_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquot7Dot5Range()
        {
            //Arrange
            decimal grossSalary = 1045;
            decimal aliquot = 7.5m;
            decimal expectedDiscountINSSValue = grossSalary * aliquot / 100;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountINSS = new DiscountINSS(_employee.Object.GrossSalary);

            //Assert
            discountINSS.Value.Should().Be(expectedDiscountINSSValue);
        }

        [Test]
        public void DiscountINSS_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquot9Range()
        {
            //Arrange
            decimal grossSalary = 2089.60m;
            decimal aliquot = 9;
            decimal expectedDiscountINSSValue = grossSalary * aliquot / 100;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountINSS = new DiscountINSS(_employee.Object.GrossSalary);

            //Assert
            discountINSS.Value.Should().Be(expectedDiscountINSSValue);
        }

        [Test]
        public void DiscountINSS_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquot12Range()
        {
            //Arrange
            decimal grossSalary = 3134.40m;
            decimal aliquot = 12;
            decimal expectedDiscountINSSValue = grossSalary * aliquot / 100;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountINSS = new DiscountINSS(_employee.Object.GrossSalary);

            //Assert
            discountINSS.Value.Should().Be(expectedDiscountINSSValue);
        }

        [Test]
        public void DiscountINSS_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquot14Range()
        {
            //Arrange
            decimal grossSalary = 6101.06m;
            decimal aliquot = 14;
            decimal expectedDiscountINSSValue = grossSalary * aliquot / 100;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountINSS = new DiscountINSS(_employee.Object.GrossSalary);

            //Assert
            discountINSS.Value.Should().Be(expectedDiscountINSSValue);
        }
    }
}