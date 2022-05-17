namespace Payslip.Domain.Features.Launches
{
    public class Launch
    {
        public Launch(LaunchType launchType, decimal value, string description)
        {
            Type = launchType;
            Value = value;
            Description = description;
        }

        public LaunchType Type { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
    }
}
