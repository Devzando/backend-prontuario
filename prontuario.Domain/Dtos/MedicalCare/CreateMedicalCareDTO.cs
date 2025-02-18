namespace prontuario.Domain.Dtos.MedicalCare;

public record CreateMedicalCareDTO(
    string? BreathingPattern,
    string? Pulmonar,
    string? ColoracaoPele,
    string? Pupila,
    string? Fala,
    string? NivelDeConsciencia,
    string? RespostaMotora,
    string? Bulhas,
    string? Ritmo,
    string? Pulso,
    long serviceId
    );