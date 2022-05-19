using Payslip.Domain.Features.Discounts;

namespace Payslip.Domain.Features.Launches
{
    public class Launch
    {
        public Launch(LaunchType launchType, Discount discount)
        {
            Type = launchType;
            Value = discount.Value;
            Description = discount.Description;
        }

        public LaunchType Type { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
    }
}