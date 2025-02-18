using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.HealthAndDisease;
using prontuario.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Usecases.HealthAndDisease
{
    public class AddHealthAndDiseaseUseCase(IMedicalRecordGateway medicalRecordGateway)
    {
        public async Task<ResultPattern<string>> Execute(CreateHealthAndDiseaseDTO data)
        {
            if (data == null)
                return ResultPattern<string>.FailureResult("Dados inválidos", 400);

            var medicalRecord = await medicalRecordGateway.FindById(data.MedicalRecordId);
            if (medicalRecord is null)
                return ResultPattern<string>.FailureResult($"Ficha médica {data.MedicalRecordId} não encontrada", 404);

            if (medicalRecord.HealthAndDisease is not null)
                return ResultPattern<string>.FailureResult("Ficha médica já possui antecedentes cadastrados", 400);

            var healthAndDisease = HealthAndDiseaseFactory.CreateHealthAndDiseaseEntity(data);
            healthAndDisease.MedicalRecord = medicalRecord;

            medicalRecord.SetHealthAndDisease(healthAndDisease);

            await medicalRecordGateway.Save(medicalRecord);

            return ResultPattern<string>.SuccessResult("Antecedentes adicionados com sucesso");
        }
    }

}
