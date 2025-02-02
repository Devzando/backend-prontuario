using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.PatientExams;
using prontuario.WebApi.ResponseModels.PatientMonitoring;

namespace prontuario.WebApi.ResponseModels.MedicalRecord;

public record MedicalRecordResponse(
    long Id,
    string? status,
    string? StatusInCaseOfAdmission,
    AnamneseResponse? Anamnese,
    List<PatientMonitoringResponse>? PatientMonitorings,
    List<PatientExamsResponse>? PatientExams
    );