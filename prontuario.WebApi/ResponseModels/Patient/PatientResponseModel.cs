using prontuario.Domain.Entities.Patient;
using prontuario.WebApi.ResponseModels.Address;
using prontuario.WebApi.ResponseModels.EmergencyContactDetails;
using prontuario.WebApi.ResponseModels.Service;

namespace prontuario.WebApi.ResponseModels.Patient
{
    public class PatientResponseModel
    {
        public static PatientResponse CreateGetAllPatientResponse(PatientEntity entity)
        {
            return new PatientResponse(
                entity.Id,
                entity.Name,
                entity.SocialName,
                entity.BirthDate,
                entity.Sus?.Value,
                entity.Cpf.Value,
                entity.Rg?.Value,
                entity.Phone?.Value,
                entity.MotherName,
                entity.Status?.Value,
                new AddressResponse(
                    entity.AddressEntity.Id,
                    entity.AddressEntity.Cep?.Value,
                    entity.AddressEntity.City,
                    entity.AddressEntity.Street,
                    entity.AddressEntity.Number,
                    entity.AddressEntity.Neighborhood
                ),
                entity.EmergencyContactDetailsEntity.Select(em => new EmergencyContactDetailsResponse(
                    em.Id,
                    em.Name,
                    em.Phone?.Value,
                    em.Relationship?.Value
                )).ToList(),
                entity.ServicesEntity?.Where(service => service.PatientId == entity.Id).Select(service => new ServiceResponseBuilder()
                    .WithId(service.Id)
                    .WithServiceDate(service.ServiceDate)
                    .WithServiceStatus(service.ServiceStatus.Value)
                    .Build())
                    .ToList());
        }
    }
}
