using prontuario.Domain.Entities.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Domain.Entities.PatientMedication
{
    public class PatientMedicationEntity
    {
        public long Id { get; private set; }
        public DateTime PrescriptionDate { get; private set; }
        public DateTime? ExecutionDate { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public long MedicalRecordId { get; private set; }
        public MedicalRecordEntity MedicalRecord { get; set; } = null!;

        public PatientMedicationEntity(long id, DateTime prescriptionDate, DateTime? executionDate, string description, long medicalRecordId)
        {
            Id = id;
            PrescriptionDate = prescriptionDate;
            ExecutionDate = executionDate;
            Description = description;
            MedicalRecordId = medicalRecordId;
        }
        public void FinalizeMedication(DateTime executionDate)
        {
            if (ExecutionDate.HasValue)
                throw new InvalidOperationException("Medicacao ja esta finalizado.");

            ExecutionDate = executionDate;
        }
    }

}
