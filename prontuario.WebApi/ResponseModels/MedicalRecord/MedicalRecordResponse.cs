using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.HealthAndDisease;
using prontuario.WebApi.ResponseModels.MedicalCare;
using prontuario.WebApi.ResponseModels.PatientExams;
using prontuario.WebApi.ResponseModels.PatientMedications;
using prontuario.WebApi.ResponseModels.PatientMonitoring;

namespace prontuario.WebApi.ResponseModels.MedicalRecord;

public record MedicalRecordResponse(
    long Id,
    string? status,
    string? StatusInCaseOfAdmission,
    AnamneseResponse? Anamnese,
    HealthAndDiseaseResponse? HealthAndDisease,
    List<PatientMonitoringResponse>? PatientMonitorings,
    List<PatientExamsResponse>? PatientExams,
    List<PatientMedicationResponse>? PatientMedications,
    MedicalCareResponse? MedicalCare
);
