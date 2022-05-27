using FluentValidation.TestHelper;
using NUnit.Framework;
using Payslip.Application.Features.Employees.Commands;
using System;

namespace Payslip.Application.Tests.Features.Employees.Commands
{
    [TestFixture]
    [Category("Payslip.Application.Tests.Employees.Commands")]
    public class EmployeeRemoveCommandValidatorTest
    {
        private EmployeeRemoveCommand _employeeRemoveCommand;
        private EmployeeRemoveCommandValidator _validator;


        [SetUp]
        public void Setup()
        {
            _employeeRemoveCommand = new EmployeeRemoveCommand
            {
            };

            _validator = new EmployeeRemoveCommandValidator();
        }

        [Test]
        public void EmployeeId_ShouldNotHaveError_WhenInformedValueIsNotNull()
        {
            //Arrange
            _employeeRemoveCommand.EmployeeId = Guid.NewGuid();

            //Action
            var result = _validator.TestValidate(_employeeRemoveCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.EmployeeId);
        }

        [Test]
        public void EmployeeId_ShouldHaveError_WhenInformedValueIsNullOrEmpty()
        {
            //Action
            var result = _validator.TestValidate(_employeeRemoveCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.EmployeeId).WithErrorMessage("Informe o identificador do funcionário.");
        }
    }
}
