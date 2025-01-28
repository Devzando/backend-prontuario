using prontuario.Domain.Entities.PatientMonitoring;

namespace prontuario.WebApi.ResponseModels.PatientMonitoring
{
    public class PatientMonitoringResponseModels
    {
        public static PatientMonitoringResponse CreatePatientmonitoringResponse(PatientMonitoringEntity patientMonitoring)
        {
            var patientMonitoringResponse = new PatientMonitoringResponseBuilder()
                .WithId(patientMonitoring.Id)
                .WithGlucose(patientMonitoring.Glucose)
                .WithBloodPressure(patientMonitoring.BloodPressure)
                .WithTemperature(patientMonitoring.Temperature)
                .WithMonitoringDate(patientMonitoring.MonitoringDate)
                .Build();

            return patientMonitoringResponse;
        }
    }
}
