﻿using Payslip.Core.DomainObjects;

namespace Payslip.Domain.Features.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Department { get; set; }
        public decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; private set; }
        public bool HealthPlan { get; set; }
        public bool DentalPlan { get; set; }
        public bool TransportantionVoucher { get; set; }
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