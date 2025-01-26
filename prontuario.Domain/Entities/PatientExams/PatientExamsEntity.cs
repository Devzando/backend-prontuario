using prontuario.Domain.Entities.MedicalRecord;
using System;

namespace prontuario.Domain.Entities.PatientExams
{
    public class PatientExamsEntity
    {

        public long Id { get; private set; }
        public DateTime PrescriptionDate { get; private set; }
        public DateTime? ExecutionDate { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public long MedicalRecordId { get; private set; }
        public MedicalRecordEntity MedicalRecord { get; set; } = null!;

        public PatientExamsEntity() { }

        public PatientExamsEntity(long id, DateTime prescriptionDate, DateTime? executionDate, string description, long medicalRecordId)
        {
            Id = id;
            PrescriptionDate = prescriptionDate;
            ExecutionDate = executionDate;
            Description = description;
            MedicalRecordId = medicalRecordId;
        }
    }
}
