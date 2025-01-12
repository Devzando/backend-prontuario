using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.MedicalRecord;

namespace prontuario.WebApi.ResponseModels.Service;

public record ServiceResponse(
    long Id,
    DateTime ServiceDate,
    string? ServiceStatus,
    MedicalRecordResponse? MedicalRecord
    );