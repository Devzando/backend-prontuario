using prontuario.Application.Gateways;
using prontuario.Domain.Entities.Nursing;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Errors;
using prontuario.Domain.Utils;

namespace prontuario.Application.Usecases.Patient;

public class FindAllNursingNoteUseCase(INursingGateway nursingGateway)
{
    public async Task<ResultPattern<PagedResult<List<NursingEntity>?>>> Execute(int pagenumber = 0, int pagesize = 20)
    {
        var result = await nursingGateway.GetByFilterList(pagenumber, pagesize);
        return ResultPattern<PagedResult<List<NursingEntity>?>>.SuccessResult(result);
    }
}