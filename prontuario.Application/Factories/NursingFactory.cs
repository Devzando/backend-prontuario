using prontuario.Domain.Dtos.Nursing;
using prontuario.Domain.Entities.Nursing;

namespace prontuario.Application.Factories
{
    public class NursingFactory
    {
        public static NursingEntity CreateNursingNote(CreateNursingNoteDTO data)
        {
            return new NursingEntityBuilder()
                .WithNursingNote(data.NursingNote)
                .WithPatientId(data.PatientId)
                .Build();
        }
    }
}
