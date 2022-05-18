namespace Payslip.Domain.Features.Discounts
{
    public class DiscountDentalPlan : Discount
    {
        public DiscountDentalPlan(bool hasDentalPlan)
        {
            if (hasDentalPlan) Value = 5;
        }
    }
}
