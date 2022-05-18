using FluentAssertions;
using Moq;
using NUnit.Framework;
using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;

namespace Payslip.Domain.Tests.Features.Discounts
{
    [TestFixture]
    [Category("Payslip.Domain.Tests.Discounts")]
    public class DiscountDentalPlanTest
    {
        private Mock<Employee> _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Mock<Employee>();
        }

        [Test]
        public void DiscountDentalPlan_ShoudReturnCorrectValue_WhenEmployeeHasDentalPlan()
        {
            //Arrange
            bool hasDentalPlan = true;
            decimal expectedDentalPlanValue = 5;
            _employee.Setup(e => e.DentalPlan).Returns(hasDentalPlan);

            //Action
            var dentalPlanDiscount = new DiscountDentalPlan(_employee.Object.DentalPlan);

            //Assert
            dentalPlanDiscount.Value.Should().Be(expectedDentalPlanValue);
        }

        [Test]
        public void DiscountDentalPlan_ShoudReturnCorrectValue_WhenEmployeeDoNoHaveDentalPlan()
        {
            //Arrange
            bool hasDentalPlan = false;
            decimal expectedDentalPlanValue = 0;
            _employee.Setup(e => e.DentalPlan).Returns(hasDentalPlan);

            //Action
            var dentalPlanDiscount = new DiscountDentalPlan(_employee.Object.DentalPlan);

            //Assert
            dentalPlanDiscount.Value.Should().Be(expectedDentalPlanValue);
        }
    }
}
