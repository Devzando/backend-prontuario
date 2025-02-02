using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.PatientExams;
using prontuario.WebApi.ResponseModels.PatientMonitoring;

namespace prontuario.WebApi.ResponseModels.MedicalRecord;

public class MedicalRecordResponseBuilder
{
    private long _id;
    private string? _status;
    private string? _statusInCaseOfAdmission;
    private AnamneseResponse? _anamnese;
    private List<PatientExamsResponse>? _patientExams;
    private List<PatientMonitoringResponse>? _patientMonitoring;

    public MedicalRecordResponseBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public MedicalRecordResponseBuilder WithStatus(string? status)
    {
        _status = status;
        return this;
    }

    public MedicalRecordResponseBuilder WithStatusInCaseOfAdmission(string? statusInCaseOfAdmission)
    {
        _statusInCaseOfAdmission = statusInCaseOfAdmission;
        return this;
    }

    public MedicalRecordResponseBuilder WithAnamnese(AnamneseResponse? anamnese)
    {
        _anamnese = anamnese;
        return this;
    }

    public MedicalRecordResponseBuilder WithPatientExams(List<PatientExamsResponse>? patientExams)
    {
        _patientExams = patientExams;
        return this;
    }

    public MedicalRecordResponseBuilder WithPatientMonitoring(List<PatientMonitoringResponse>? patientMonitoring)
    {
        _patientMonitoring = patientMonitoring;
        return this;
    }

    public MedicalRecordResponse Build()
    {
        return new MedicalRecordResponse(
            _id,
            _status,
            _statusInCaseOfAdmission,
            _anamnese,
            _patientMonitoring,
            _patientExams
        );
    }
}