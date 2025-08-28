using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.Notes;
using prontuario.Domain.Entities.Notes;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Notes
{
    public class CreateNoteUseCase(
        INotesGateway notesGateway,
        IUserGateway userGateway,
        IGatewayPatient patientGateway)
    {
        public async Task<ResultPattern<NotesEntity>> Execute(CreateNotesDTO data)
        {
            var user = await userGateway.FindUserById(data.UserId);
            if (user is null)
                return ResultPattern<NotesEntity>.FailureResult("Usuário não encontrado. Não foi possível criar a anotação", 404);

            var patient = await patientGateway.GetById(data.PatientId);
            if (patient is null)
                return ResultPattern<NotesEntity>.FailureResult("Paciente não encontrado. Não foi possível criar a anotação", 404);

            var noteEntity = NotesFactory.CreateNotes(data.Description, patient, user);
            await notesGateway.CreateNote(noteEntity);
            return ResultPattern<NotesEntity>.SuccessResult(noteEntity);
        }
    }
}
