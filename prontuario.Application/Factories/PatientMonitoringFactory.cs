using prontuario.Domain.Dtos.PatientMonitoring;
using prontuario.Domain.Entities.PatientMonitoring;

namespace prontuario.Application.Factories
{
    public class PatientMonitoringFactory
    {
        public static PatientMonitoringEntity CreatePatientMonitoringEntity(CreatePatientMonitoringDTO data)
        {
            return new PatientMonitoringEntityBuilder()
                .WithBloodPressure(data.BloodPressure)
                .WithGlucose(data.Glucose)
                .WithTemperature(data.Temperature)
                .WithSaturation(data.Saturation)
                .WithRespiratoryRate(data.RespiratoryRate)
                .WithMedicalRecordId(data.MedicalRecordId)
                .Build();
        }   
    }
}
