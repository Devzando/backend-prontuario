using prontuario.Domain.Entities.MedicalCare;

namespace prontuario.Domain.Dtos.MedicalCare
{
    public record CreateCardioDTO(
        MedicalCareEntity MedicalCareEntity, 
        String Ritmo,
        String Pulso,
        String Bulhas)
    {
    }
}
