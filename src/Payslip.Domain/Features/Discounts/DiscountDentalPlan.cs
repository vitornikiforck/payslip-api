namespace Payslip.Domain.Features.Discounts
{
    public class DiscountDentalPlan : Discount
    {
        public DiscountDentalPlan(bool hasDentalPlan)
        {
            Description = "Plano Dental";
            if (hasDentalPlan) Value = 5;
        }
    }
}
