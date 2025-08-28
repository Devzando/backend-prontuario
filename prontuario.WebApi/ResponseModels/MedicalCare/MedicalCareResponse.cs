namespace prontuario.WebApi.ResponseModels.MedicalCare;

public record MedicalCareResponse(
    long Id, 
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