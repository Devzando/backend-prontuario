using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalCare;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalCare;

public class CreateMedicalCareUseCase(IMedicalCareGateway medicalCareGateway, IServiceGateway serviceGateway)
{
    public async Task<ResultPattern<string>> Execute(CreateMedicalCareDTO data)
    {
        var serviceEntity = await serviceGateway.FindById(data.serviceId);
        var medicalCareEntity = MedicalCareFactory.Create(data);
        serviceEntity!.MedicalCareEntity = medicalCareEntity;
        await serviceGateway.Update(serviceEntity);
        return ResultPattern<string>.SuccessResult();
    }
}