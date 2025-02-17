using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalRecord;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalRecord;

public class ChangeMedicalRecordStatusUseCase(IServiceGateway serviceGateway)
{
    public async Task<ResultPattern<string>> Execute(ChangeMedicalRecordStatusDTO data)
        {
            var service = await serviceGateway.FindById(data.Id);
            if (service == null)
            {
                return ResultPattern<string>.FailureResult("Service not found", 404, "Not Found");
            }

            var MedicalRecordEntity = MedicalRecordFactory.ChangeMedicalRecordStatus(data, service);
            await serviceGateway.Update(MedicalRecordEntity);
            return ResultPattern<string>.SuccessResult();
        }
}