using prontuario.Domain.Entities.Patient;

namespace prontuario.Domain.Dtos.Nursing
{
    public record CreateNursingNoteDTO(string NursingNote, PatientEntity PatientEntity)
    {
    }
}
