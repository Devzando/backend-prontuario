using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.MedicalCare;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Service
{
    public class ServiceEntity
    {
        public long Id { get; private set; }
        public string? ServiceStatus { get; set; }
        public DateTime ServiceDate { get; private set; }
        public MedicalRecordEntity? MedicalRecordEntity { get; set; }
        public MedicalCareEntity? MedicalCareEntity { get; set; }
        public PatientEntity PatientEntity { get; set; } = null!;
        public long PatientId { get; private set; }
        public ServiceEntity() { }

        public ServiceEntity(long id, string? serviceStatus, DateTime serviceDate, PatientEntity patientEntity, MedicalRecordEntity? medicalRecordEntity, MedicalCareEntity? medicalCareEntity)
        {
            this.Id = id;
            this.ServiceStatus = serviceStatus;
            this.ServiceDate = serviceDate;
            this.PatientEntity = patientEntity;
            this.MedicalRecordEntity = medicalRecordEntity;
            this.MedicalCareEntity = medicalCareEntity;
        }
    }
}
