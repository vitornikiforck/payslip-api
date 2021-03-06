namespace Payslip.Api.Controllers.Employees.ViewModels
{
    /// <summary>
    /// 
    /// Representa o resultado de uma consulta de funcionário da base de dados
    /// 
    /// É usado quando se precisa consultar mais dados sobre o funcionário
    ///  
    /// </summary>
    public class EmployeeDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Department { get; set; }
        public decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool HealthPlan { get; set; }
        public bool DentalPlan { get; set; }
        public bool TransportantionVoucher { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}