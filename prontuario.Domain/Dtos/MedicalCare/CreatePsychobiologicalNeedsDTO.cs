using prontuario.Domain.Entities.MedicalCare;

namespace prontuario.Domain.Dtos.MedicalCare
{
    public record CreatePsychobiologicalNeedsDTO(
        MedicalCareEntity MedicalCareEntity, 
        String BreathingPattern,
        String Pulmonar,
        String ColoracaoPele)
    {
    }
}
