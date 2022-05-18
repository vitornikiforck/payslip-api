using FluentAssertions;
using Moq;
using NUnit.Framework;
using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;

namespace Payslip.Domain.Tests.Features.Discounts
{
    [TestFixture]
    [Category("Payslip.Domain.Tests.Discounts")]
    public class DiscountIRRFTest
    {
        private Mock<Employee> _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Mock<Employee>();
        }

        [Test]
        public void DiscountIRRF_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquotZeroRange()
        {
            //Arrange
            decimal grossSalary = 1903.98m;
            decimal aliquot = 0;
            decimal expectedDiscountIRRFValue = grossSalary * aliquot / 100;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountIRRF = new DiscountIRRF(_employee.Object.GrossSalary);

            //Assert
            discountIRRF.Value.Should().Be(expectedDiscountIRRFValue);
        }

        [Test]
        public void DiscountIRRF_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquotSevenDotFiveRangeAndHasDiscountRoof()
        {
            //Arrange
            decimal grossSalary = 2826.65m;
            decimal expectedDiscountIRRFValue = 142.8m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountIRRF = new DiscountIRRF(_employee.Object.GrossSalary);

            //Assert
            discountIRRF.Value.Should().Be(expectedDiscountIRRFValue);
        }

        [Test]
        public void DiscountIRRF_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquotSevenDotFiveRangeAndNotHaveDiscountRoof()
        {
            //Arrange
            decimal grossSalary = 1903.99m;
            decimal aliquot = 7.5m;
            decimal expectedDiscountIRRFValue = grossSalary * aliquot / 100;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountIRRF = new DiscountIRRF(_employee.Object.GrossSalary);

            //Assert
            discountIRRF.Value.Should().Be(expectedDiscountIRRFValue);
        }

        [Test]
        public void DiscountIRRF_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquotFifteenRangeAndHasDiscountRoof()
        {
            //Arrange
            decimal grossSalary = 3751.05m;
            decimal expectedDiscountIRRFValue = 354.8m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountIRRF = new DiscountIRRF(_employee.Object.GrossSalary);

            //Assert
            discountIRRF.Value.Should().Be(expectedDiscountIRRFValue);
        }

        [Test]
        public void DiscountIRRF_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquotTwentyTwoDotFiveRangeAndHasDiscountRoof()
        {
            //Arrange
            decimal grossSalary = 4664.68m;
            decimal expectedDiscountIRRFValue = 636.13m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountIRRF = new DiscountIRRF(_employee.Object.GrossSalary);

            //Assert
            discountIRRF.Value.Should().Be(expectedDiscountIRRFValue);
        }

        [Test]
        public void DiscountIRRF_ShoudReturnCorrectValue_WhenGrossSalaryLessThanAliquotTwentySevenDotFiveRangeAndHasDiscountRoof()
        {
            //Arrange
            decimal grossSalary = 4664.69m;
            decimal expectedDiscountIRRFValue = 869.36m;
            _employee.Setup(e => e.GrossSalary).Returns(grossSalary);

            //Action
            var discountIRRF = new DiscountIRRF(_employee.Object.GrossSalary);

            //Assert
            discountIRRF.Value.Should().Be(expectedDiscountIRRFValue);
        }
    }
}