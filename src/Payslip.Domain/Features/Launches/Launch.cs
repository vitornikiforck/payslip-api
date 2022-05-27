using Payslip.Domain.Features.Discounts;

namespace Payslip.Domain.Features.Launches
{
    /// <summary>
    /// Representa um lançamento do contracheque
    /// </summary>
    public class Launch
    {
        public Launch(LaunchType launchType, Discount discount)
        {
            Type = launchType;
            Value = discount.Value;
            Description = discount.Description;
        }

        /// <summary>
        /// Tipo do Lançamento(Disconto/Remuneração)
        /// </summary>
        public LaunchType Type { get; private set; }
        /// <summary>
        /// Valor do Lançamento
        /// </summary>
        public decimal Value { get; private set; }
        /// <summary>
        /// Descrição do Lançamento(INSS/FGTS..)
        /// </summary>
        public string Description { get; private set; }
    }
}