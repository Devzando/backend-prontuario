using prontuario.WebApi.ResponseModels.Anamnese;

namespace prontuario.WebApi.ResponseModels.MedicalRecord;

public record MedicalRecordResponse(
    long Id,
    string? status,
    AnamneseResponse? Anamnese
    );