using FluentAssertions;
using Moq;
using NUnit.Framework;
using Payslip.Domain.Features.Discounts;
using Payslip.Domain.Features.Employees;

namespace Payslip.Domain.Tests.Features.Discounts
{
    [TestFixture]
    [Category("Payslip.Domain.Tests.Discounts")]
    public class DiscountHealthPlanTest
    {
        private Mock<Employee> _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Mock<Employee>();
        }

        [Test]
        public void DiscountHealthPlan_ShoudReturnCorrectValue_WhenEmployeeHasHealthPlan()
        {
            //Arrange
            bool hasHealthPlan = true;
            decimal expectedHealthPlanValue = 10;
            _employee.Setup(e => e.HealthPlan).Returns(hasHealthPlan);

            //Action
            var healthPlanDiscount = new DiscountHealthPlan(_employee.Object.HealthPlan);

            //Assert
            healthPlanDiscount.Value.Should().Be(expectedHealthPlanValue);
        }

        [Test]
        public void DiscountHealthPlan_ShoudReturnCorrectValue_WhenEmployeeDoNotHaveHealthPlan()
        {
            //Arrange
            bool hasHealthPlan = false;
            decimal expectedHealthPlanValue = 0;
            _employee.Setup(e => e.HealthPlan).Returns(hasHealthPlan);

            //Action
            var healthPlanDiscount = new DiscountHealthPlan(_employee.Object.HealthPlan);

            //Assert
            healthPlanDiscount.Value.Should().Be(expectedHealthPlanValue);
        }
    }
}
