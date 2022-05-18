using Payslip.Core.DomainObjects;

namespace Payslip.Domain.Features.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Department { get; set; }
        public virtual decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; private set; }
        public virtual bool HealthPlan { get; set; }
        public virtual bool DentalPlan { get; set; }
        public virtual bool TransportantionVoucher { get; set; }
        public DateTime UpdateAt { get; private set; }
        public bool IsRemoved { get; set; }

        public Employee()
        {
            AdmissionDate = DateTime.UtcNow;
            UpdateAt = AdmissionDate;
        }

        public virtual void SetAsRemoved()
        {
            SetLastModification();
            IsRemoved = true;
        }

        public virtual void SetLastModification() => UpdateAt = DateTime.UtcNow;
    }
}