namespace prontuario.Domain.Dtos.PatientMonitoring
{
    public record CreatePatientMonitoringDTO(long MedicalRecordId, string BloodPressure, string Glucose, string Temperature, string Saturation, string RespiratoryRate)
    {
    }
}
