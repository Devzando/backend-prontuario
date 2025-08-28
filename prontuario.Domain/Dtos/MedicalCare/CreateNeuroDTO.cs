using prontuario.Domain.Entities.MedicalCare;

namespace prontuario.Domain.Dtos.MedicalCare
{
    public record CreateNeuroDTO(
        MedicalCareEntity MedicalCareEntity, 
        String Pupila,
        String Fala,
        String NivelDeConsciencia,
        String RespostaMotora)
    {
    }
}
