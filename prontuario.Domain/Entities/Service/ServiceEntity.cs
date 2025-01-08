using prontuario.Domain.Entities.MedicalRecord;

namespace prontuario.Domain.Entities.Service
{
    public class ServiceEntity
    {
        public long? Id { get; private set; }
        public bool ServiceStatus { get; private set; } = false;
        public PatientEntity PatientEntity { get; private set; } = null!;
        public DateTime ServiceDate { get; private set; }
        public MedicalRecordEntity MedicalRecordEntity { get; private set; } = null!;
        public ServiceEntity() { }

        public ServiceEntity(long? id, bool serviceStatus, PatientEntity patientEntity, DateTime serviceDate, MedicalRecordEntity medicalRecordEntity)
        {
            this.Id = id;
            this.ServiceStatus = serviceStatus;
            this.PatientEntity = patientEntity;
            this.ServiceDate = serviceDate;
            this.MedicalRecordEntity = medicalRecordEntity;
        }
    }
}
