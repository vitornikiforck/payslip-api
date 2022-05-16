namespace Payslip.Domain.Features.Discounts
{
    public abstract partial class Discount
    {
        protected abstract decimal Calculate(decimal grossSalary);
    }
}
