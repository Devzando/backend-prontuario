using prontuario.Application.Gateways;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.Errors;
using prontuario.Domain.Utils;

namespace prontuario.Application.Usecases.Service;

public class FindAllServicesByPatientIdUseCase(IServiceGateway serviceGateway)
{
    public async Task<ResultPattern<PagedResult<List<ServiceEntity>?>>> Execute(long patientId, int pageNumber, int pageSize)
    {
        var services = await serviceGateway.FindAllByPatientId(patientId, pageNumber, pageSize);
        return ResultPattern<PagedResult<List<ServiceEntity>?>>.SuccessResult(services);
    }
}