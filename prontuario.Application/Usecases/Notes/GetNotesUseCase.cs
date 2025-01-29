using prontuario.Application.Gateways;
using prontuario.Domain.Entities.Notes;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Notes
{
    public class GetNotesUseCase(INotesGateway notesGateway)
    {
        public async Task<ResultPattern<List<NotesEntity>>> Execute(long patientId)
        {
            var notes = await notesGateway.GetNotesByPatient(patientId);

            if (notes == null)
                return ResultPattern<List<NotesEntity>>.FailureResult("Nenhuma anotação encontrada", 404);

            return ResultPattern<List<NotesEntity>>.SuccessResult(notes);
        }
    }
}
