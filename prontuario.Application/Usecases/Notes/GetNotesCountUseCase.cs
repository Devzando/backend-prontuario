using prontuario.Application.Gateways;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Notes
{
    public class GetNotesCountUseCase(INotesGateway notesGateway)
    {
        public async Task<ResultPattern<long>> Execute(long patientId)
        {
            var count = await notesGateway.GetNotesCountByPatient(patientId);
            return ResultPattern<long>.SuccessResult(count);
        }
    }
}
