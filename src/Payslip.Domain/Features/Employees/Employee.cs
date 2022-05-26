using Payslip.Core.DomainObjects;

namespace Payslip.Domain.Features.Employees
{
    /// <summary>
    /// Representa um Funcionário como entidade
    /// </summary>
    public class Employee : Entity
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Sobrenome
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// CPF
        /// </summary>
        public string Document { get; set; }
        /// <summary>
        /// Setor/Departamento
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// Salário Bruto
        /// </summary>
        public virtual decimal GrossSalary { get; set; }
        /// <summary>
        /// Data de Admissão
        /// </summary>
        public DateTime AdmissionDate { get; private set; }
        /// <summary>
        /// Plano de Saúde
        /// </summary>
        public virtual bool HealthPlan { get; set; }
        /// <summary>
        /// Plano Dental
        /// </summary>
        public virtual bool DentalPlan { get; set; }
        /// <summary>
        /// Vale Transporte
        /// </summary>
        public virtual bool TransportantionVoucher { get; set; }
        /// <summary>
        /// Data da última modificação do funcionário
        /// </summary>
        public DateTime UpdateAt { get; private set; }
        /// <summary>
        /// Funcionário Removido
        /// </summary>
        public bool IsRemoved { get; private set; }

        public Employee()
        {
            AdmissionDate = DateTime.UtcNow;
            UpdateAt = AdmissionDate;
        }

        /// <summary>
        /// Atualiza data de modificação e seta o funcionário como removido
        /// </summary>
        public void SetAsRemoved()
        {
            SetLastModification();
            IsRemoved = true;
        }

        /// <summary>
        /// Seta a data de atualização do cliente para data e hora atual
        /// </summary>
        public void SetLastModification() => UpdateAt = DateTime.UtcNow;
    }
}