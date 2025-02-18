using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalRecord;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalRecord;

public class ChangeMedicalRecordStatusUseCase(IServiceGateway serviceGateway)
{
    public async Task<ResultPattern<string>> Execute(ChangeMedicalRecordStatusDTO data)
        {
            var serviceEntity = await serviceGateway.FindById(data.Id);
            if (serviceEntity == null)
            {
                return ResultPattern<string>.FailureResult("Service not found", 404, "Not Found");
            }

            var service = MedicalRecordFactory.ChangeMedicalRecordStatus(data, serviceEntity);
            await serviceGateway.Update(service);
            return ResultPattern<string>.SuccessResult();
        }
}