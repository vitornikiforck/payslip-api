namespace Payslip.Domain.Features.Discounts
{
    public class DiscountHealthPlan : Discount
    {
        public DiscountHealthPlan(bool hasDentalPlan)
        {
            Description = "Plano de Saúde";
            if (hasDentalPlan) Value = 10;
        }
    }
}
