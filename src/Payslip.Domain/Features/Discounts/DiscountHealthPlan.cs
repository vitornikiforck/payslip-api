namespace Payslip.Domain.Features.Discounts
{
    public class DiscountHealthPlan : Discount
    {
        public DiscountHealthPlan(bool hasDentalPlan)
        {
            if (hasDentalPlan) Value = 10;
        }
    }
}
