namespace prontuario.WebApi.ResponseModels.MedicalCare;

public record MedicalCareResponse(
    long Id, 
    string[]? ExamPrescription,
    string[]? MedicalPrescription,
    string? MedicalHypothesis,
    long PatiendId,
    string? BreathingPattern,
    string? Pulmonar,
    string? ColoracaoPele,
    string? Pupila,
    string? Fala,
    string? NivelDeConsciencia,
    string? RespostaMotora,
    string? Bulhas,
    string? Ritmo,
    string? Pulso
);