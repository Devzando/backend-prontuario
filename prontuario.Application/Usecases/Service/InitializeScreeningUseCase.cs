using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Service;

public class InitializeScreeningUseCase(IServiceGateway serviceGateway)
{
    public async Task<ResultPattern<string>> Execute(long serviceId)
    {
        var service = await serviceGateway.FindById(serviceId);
        if (service is null)
            return ResultPattern<string>.FailureResult("Erro ao iniciar a triagem", 404);

        var medicalRecord = MedicalRecordFactory.CreateMedicalRecordToInitScreening();
        var newService = ServiceFactory.CreateServiceToInitializeScreening(service, medicalRecord);
        await serviceGateway.Init(newService);

        return ResultPattern<string>.SuccessResult();
    }
}