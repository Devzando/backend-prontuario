using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.PatientMonitoring;

namespace prontuario.WebApi.ResponseModels.MedicalRecord;

public record MedicalRecordResponse(
    long Id,
    string? status,
    AnamneseResponse? Anamnese,
    PatientMonitoringResponse? PatienteMonitoring
    );