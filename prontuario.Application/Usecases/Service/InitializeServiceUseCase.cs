using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Service;

public class InitializeServiceUseCase(IGatewayPatient gatewayPatient, IServiceGateway serviceGateway)
{
    public async Task<ResultPattern<ServiceEntity>> Execute(long patientId)
    {
        var patient = await gatewayPatient.GetById(patientId);
        if(patient is null)
            return ResultPattern<ServiceEntity>.FailureResult("Erro ao iniciar atendimento", 404);

        var patientInitializeService = PatientFactory.CreatePatient(patient);
        var service = ServiceFactory.CreateService(patientInitializeService);
        await serviceGateway.Save(service);
        
        return ResultPattern<ServiceEntity>.SuccessResult();
    }
}