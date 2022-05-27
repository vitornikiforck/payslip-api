using Payslip.Api.Controllers.Launches;

namespace Payslip.Api.Controllers.Paymentslips.ViewModels
{
    /// <summary>
    /// 
    /// Representa o resultado da geração de um contracheque
    /// 
    /// É usado para montar os dados de retorno do contracheque
    ///  
    /// </summary>
    public class PaymentslipDetailViewModel
    {
        public int ReferenceMonth { get; set; }
        public List<LauncheDetailViewModel> Launches { get; set; }
        public decimal GrossSalary { get; private set; }
        public decimal TotalDiscountValue { get; set; }
        public decimal NetSalary { get; set; }
    }
}