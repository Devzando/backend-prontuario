using prontuario.Domain.Entities.Patient;
using prontuario.Domain.ValuesObjects;
using prontuario.WebApi.ResponseModels.Address;
using prontuario.WebApi.ResponseModels.EmergencyContactDetails;

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
                new EmergencyContactDetailsResponse(
                    entity.EmergencyContactDetailsEntity.Id,
                    entity.EmergencyContactDetailsEntity.Name,
                    entity.EmergencyContactDetailsEntity.Phone?.Value,
                    entity.EmergencyContactDetailsEntity.Relationship?.Value
                ));
        }
    }
}
