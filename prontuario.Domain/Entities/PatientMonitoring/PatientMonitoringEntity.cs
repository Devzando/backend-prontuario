using prontuario.Domain.Entities.MedicalRecord;

namespace prontuario.Domain.Entities.PatientMonitoring
{
    public class PatientMonitoringEntity
    {
        public long Id { get; private set; }
        public string BloodPressure { get; private set; } = string.Empty;
        public string Glucose { get; private set; } = string.Empty;
        public string Temperature { get; private set; } = string.Empty;
        public string Saturation { get; private set; } = string.Empty;
        public string RespiratoryRate { get; private set; } = string.Empty;
        public long MedicalRecordId { get; private set; }
        public MedicalRecordEntity MedicalRecord { get; private set; } = null!;
        public PatientMonitoringEntity()
        {
        }

        public PatientMonitoringEntity(long id, string bloodPressure, string glucose, string temperature, string saturation, string respiratoryRate)
        {
            Id = id;
            BloodPressure = bloodPressure;
            Glucose = glucose;
            Temperature = temperature;
            Saturation = saturation;
            RespiratoryRate = respiratoryRate;
        }

    }
}
