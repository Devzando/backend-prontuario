using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.Anamnese;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalRecord;

public class CreateAnamneseUseCase(IMedicalRecordGateway medicalRecordGateway, IServiceGateway serviceGateway)
{
    public async Task<ResultPattern<string>> Execute(CreateAnamneseDTO data)
    {
        var service = await serviceGateway.FindById(data.ServiceId);
        if(service is null)
            return ResultPattern<string>.FailureResult("Erro ao adicionar Anamnese", 404);

        var anamnese = AnamneseFactory.CreateAnamneseEntity(data);
        var medicalRecord = MedicalRecordFactory.CreateMedicalRecordWithAnamnese(service.MedicalRecordEntity!, anamnese);
        await medicalRecordGateway.Save(medicalRecord);

        return ResultPattern<string>.SuccessResult();
    }
}