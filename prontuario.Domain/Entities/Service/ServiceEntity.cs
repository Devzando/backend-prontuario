using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Service
{
    public class ServiceEntity
    {
        public long? Id { get; private set; }
        public ServiceStatus ServiceStatus { get; private set; }
        public PatientEntity PatientEntity { get; private set; } = null!;
        public DateTime ServiceDate { get; private set; }
        public MedicalRecordEntity? MedicalRecordEntity { get; private set; }
        public ServiceEntity() { }

        public ServiceEntity(long? id, ServiceStatus serviceStatus, PatientEntity patientEntity, DateTime serviceDate, MedicalRecordEntity? medicalRecordEntity)
        {
            this.Id = id;
            this.ServiceStatus = serviceStatus;
            this.PatientEntity = patientEntity;
            this.ServiceDate = serviceDate;
            this.MedicalRecordEntity = medicalRecordEntity;
        }
    }
}
