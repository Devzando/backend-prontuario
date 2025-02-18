using prontuario.Domain.Entities.MedicalRecord;
using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.HealthAndDisease;
using prontuario.WebApi.ResponseModels.PatientExams;
using prontuario.WebApi.ResponseModels.PatientMedications;
using prontuario.WebApi.ResponseModels.PatientMonitoring;

namespace prontuario.WebApi.ResponseModels.MedicalRecord;

public class MedicalRecordResponseModels
{
    public static MedicalRecordResponse CreateCompleteMedicalRecordResponse(MedicalRecordEntity medicalRecordEntity)
    {
        var patientExamsResponse = medicalRecordEntity.PatientExams?.Select(exam =>
            PatientExamsResponseModels.CreatePatientExamsResponse(exam)
        ).ToList();

        var patientMonitoringResponse = medicalRecordEntity.PatientMonitoring?.Select(monitoring =>
            PatientMonitoringResponseModels.CreatePatientmonitoringResponse(monitoring)
        ).ToList();

        var patientMedicationsResponse = medicalRecordEntity.PatientMedications?.Select(medication =>
            PatientMedicationResponseModels.CreatePatientExamsResponse(medication)
        ).ToList();

        var healthAndDiseaseResponse = medicalRecordEntity.HealthAndDisease == null
            ? null
            : HealthAndDiseaseResponseModels.CreateHealthAndDiseaseResponse(medicalRecordEntity.HealthAndDisease);

        var medicalRecordResponse = new MedicalRecordResponseBuilder()
            .WithId(medicalRecordEntity.Id)
            .WithStatus(medicalRecordEntity.Status.Value)
            .WithStatusInCaseOfAdmission(medicalRecordEntity.StatusInCaseOfAdmission.Value)
            .WithAnamnese(medicalRecordEntity.Anamnese == null ? null : AnamneseResponseModels.CreateCompleteAnamneseReponse(medicalRecordEntity.Anamnese!))
            .WithHealthAndDisease(healthAndDiseaseResponse)
            .WithPatientExams(patientExamsResponse)
            .WithPatientMedications(patientMedicationsResponse)
            .WithPatientMonitoring(patientMonitoringResponse)
            .Build();

        return medicalRecordResponse;
    }
}
