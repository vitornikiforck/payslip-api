using FluentValidation.TestHelper;
using NUnit.Framework;
using Payslip.Application.Features.Paymentslips.Queries;
using System;

namespace Payslip.Application.Tests.Features.Paymentslips.Queries
{
    [TestFixture]
    [Category("Payslip.Application.Tests.Paymentslips.Queries")]
    public class PaymentslipGenerateValidatorQueryTest
    {
        private PaymentslipGenerateQuery _paymentslipGenerateQuery;
        private GeneratePayslipQueryValidator _validator;

        [SetUp]
        public void Setup()
        {
            _paymentslipGenerateQuery = new PaymentslipGenerateQuery
            {
            };

            _validator = new GeneratePayslipQueryValidator();
        }

        [Test]
        public void EmployeeId_ShouldNotHaveError_WhenInformedValueIsNotNull()
        {
            //Arrange
            _paymentslipGenerateQuery.EmployeeId = Guid.NewGuid();

            //Action
            var result = _validator.TestValidate(_paymentslipGenerateQuery);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.EmployeeId);
        }

        [Test]
        public void EmployeeId_ShouldHaveError_WhenInformedValueIsNullOrEmpty()
        {
            //Action
            var result = _validator.TestValidate(_paymentslipGenerateQuery);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.EmployeeId).WithErrorMessage("Informe o identificador do funcionário.");
        }
    }
}