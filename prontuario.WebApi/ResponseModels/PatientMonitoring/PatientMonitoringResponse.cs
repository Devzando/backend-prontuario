namespace prontuario.WebApi.ResponseModels.PatientMonitoring
{
    public record PatientMonitoringResponse(
        long Id, 
        string? BloodPressure, 
        string? Glucose,
        string? Temperature,
        DateTime MonitoringDate,
        string? Saturation,
        string? RespiratoryRate
    );
}
