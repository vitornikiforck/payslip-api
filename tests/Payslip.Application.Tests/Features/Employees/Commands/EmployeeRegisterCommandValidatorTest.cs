using FluentValidation.TestHelper;
using NUnit.Framework;
using Payslip.Application.Features.Employees.Commands;

namespace Payslip.Application.Tests.Features.Employees.Commands
{
    [TestFixture]
    [Category("Payslip.Application.Tests.Employees.Commands")]
    public class EmployeeRegisterCommandValidatorTest
    {
        private EmployeeRegisterCommand _employeeRegisterCommand;
        private EmployeeRegisterCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _employeeRegisterCommand = new EmployeeRegisterCommand
            {
            };

            _validator = new EmployeeRegisterCommandValidator();
        }

        [Test]
        public void FirstName_ShouldNotHaveError_WhenInformedValueIsNotNullOrEmptyAndNotBiggerThanAllowed()
        {
            //Arrange
            _employeeRegisterCommand.FirstName = "Teste";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.FirstName);
        }

        [Test]
        public void FirstName_ShouldHaveError_WhenInformedValueIsNull()
        {
            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.FirstName).WithErrorMessage("Nome deve ser informado.");
        }

        [Test]
        public void FirstName_ShouldHaveError_WhenInformedValueIsEmpty()
        {
            //Arrange
            _employeeRegisterCommand.FirstName = "";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.FirstName).WithErrorMessage("Nome deve ser informado.");
        }

        [Test]
        public void FirstName_ShouldHaveError_WhenInformedValueIsBiggerThanAllowed()
        {
            //Arrange
            _employeeRegisterCommand.FirstName = new string('f', 51);

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.FirstName).WithErrorMessage("Nome não deve ultrapassar 50 caracteres.");
        }

        [Test]
        public void LastName_ShouldNotHaveError_WhenInformedValueIsNotNullOrEmptyAndNotBiggerThanAllowed()
        {
            //Arrange
            _employeeRegisterCommand.LastName = "Teste";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.LastName);
        }

        [Test]
        public void LastName_ShouldHaveError_WhenInformedValueIsNull()
        {
            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.LastName).WithErrorMessage("Sobrenome deve ser informado.");
        }

        [Test]
        public void LastName_ShouldHaveError_WhenInformedValueIsEmpty()
        {
            //Arrange
            _employeeRegisterCommand.LastName = "";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.LastName).WithErrorMessage("Sobrenome deve ser informado.");
        }

        [Test]
        public void LastName_ShouldHaveError_WhenInformedValueIsBiggerThanAllowed()
        {
            //Arrange
            _employeeRegisterCommand.LastName = new string('l', 101);

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.LastName).WithErrorMessage("Sobrenome não deve ultrapassar 100 caracteres.");
        }

        [Test]
        public void Document_ShouldNotHaveError_WhenInformedValueIsValid()
        {
            //Arrange
            _employeeRegisterCommand.Document = "99376439023";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.Document);
        }

        [Test]
        public void Document_ShouldHaveError_WhenInformedValueIsNull()
        {
            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Document).WithErrorMessage("CPF deve ser informado.");
        }

        [Test]
        public void Document_ShouldHaveError_WhenInformedValueIsEmpty()
        {
            //Arrange
            _employeeRegisterCommand.Document = "";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Document).WithErrorMessage("CPF deve ser informado.");
        }

        [Test]
        public void Document_ShouldHaveError_WhenInformedValueIsInvalid()
        {
            //Arrange
            _employeeRegisterCommand.Document = "1";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Document).WithErrorMessage("CPF está inválido.");
        }

        [Test]
        public void GrossSalary_ShouldNotHaveError_WhenInformedValueIsValid()
        {
            //Arrange
            _employeeRegisterCommand.GrossSalary = 8000.00m;

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.GrossSalary);
        }

        [Test]
        public void GrossSalary_ShouldHaveError_WhenInformedValueOutScaleDecimalPlaces()
        {
            //Arrange
            _employeeRegisterCommand.GrossSalary = 8000.000m;

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.GrossSalary).WithErrorMessage("Informe um salário válido.");
        }

        [Test]
        public void GrossSalary_ShouldHaveError_WhenInformedOutScaleValue()
        {
            //Arrange
            _employeeRegisterCommand.GrossSalary = 9999999.99m;

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.GrossSalary).WithErrorMessage("Informe um salário válido.");
        }

        [Test]
        public void Department_ShouldNotHaveError_WhenInformedValueIsNotNullOrEmptyAndNotBiggerThanAllowed()
        {
            //Arrange
            _employeeRegisterCommand.Department = "Desenvolvimento";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.Department);
        }

        [Test]
        public void Department_ShouldHaveError_WhenInformedValueIsNull()
        {
            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Department).WithErrorMessage("Setor deve ser informado.");
        }

        [Test]
        public void Department_ShouldHaveError_WhenInformedValueIsEmpty()
        {
            //Arrange
            _employeeRegisterCommand.Department = "";

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Department).WithErrorMessage("Setor deve ser informado.");
        }

        [Test]
        public void Department_ShouldHaveError_WhenInformedValueIsBiggerThanAllowed()
        {
            //Arrange
            _employeeRegisterCommand.Department = new string('l', 101);

            //Action
            var result = _validator.TestValidate(_employeeRegisterCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Department).WithErrorMessage("Setor não deve ultrapassar 100 caracteres.");
        }
    }
}