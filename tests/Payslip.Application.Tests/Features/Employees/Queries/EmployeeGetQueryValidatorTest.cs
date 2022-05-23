using FluentValidation.TestHelper;
using NUnit.Framework;
using Payslip.Application.Features.Employees.Queries;
using System;

namespace Payslip.Application.Tests.Features.Employees.Queries
{
    [TestFixture]
    [Category("Payslip.Application.Tests.Employees.Queries")]
    public class EmployeeGetQueryValidatorTest
    {
        private EmployeeGetQuery _employeeGetQuery;
        private EmployeeGetQueryValidator _validator;

        [SetUp]
        public void Setup()
        {
            _employeeGetQuery = new EmployeeGetQuery
            {
            };

            _validator = new EmployeeGetQueryValidator();
        }

        [Test]
        public void EmployeeId_ShouldNotHaveError_WhenInformedValueIsNotNull()
        {
            //Arrange
            _employeeGetQuery.EmployeeId = Guid.NewGuid();

            //Action
            var result = _validator.TestValidate(_employeeGetQuery);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.EmployeeId);
        }

        [Test]
        public void EmployeeId_ShouldHaveError_WhenInformedValueIsNullOrEmpty()
        {
            //Action
            var result = _validator.TestValidate(_employeeGetQuery);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.EmployeeId).WithErrorMessage("Informe o identificador do funcionário.");
        }
    }
}