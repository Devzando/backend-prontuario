using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;
using prontuario.Infra.Database.SqLite.EntityFramework.Models;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;

namespace prontuario.Infra.Gateways.Mappers
{
    public class PatientMapper
    {
        public static PatientEntity toEntity(PatientModel model)
        {
            return new PatientEntity(
                model.Id,
                model.Name,
                model.BirthDate,
                new SUS(model.Sus),
                new CPF(model.Cpf),
                new RG(model.Rg),
                new Phone(model.Phone),
                new AddressEntity(
                    model.AddressModel.Id,
                    new CEP(model.AddressModel.Cep),
                    model.AddressModel.Street,
                    model.AddressModel.City,
                    model.AddressModel.Number
                    ),
                new EmergencyContactDetailsEntity(
                    model.EmergencyContactDetailsModel.Id,
                    model.EmergencyContactDetailsModel.Name,
                    new Phone(model.EmergencyContactDetailsModel.Phone),
                    new Relationship(model.EmergencyContactDetailsModel.Relationship)
                    ),
                model.ServicesModel?.Select(service => new ServiceEntity(
                    
                )).ToList() ?? new List<ServiceEntity>());
        }

        public static List<PatientEntity> toEntity(List<PatientModel> models)
        {
            return models.Select(model => toEntity(model)).ToList();
        }

        public static PatientModel toModel(PatientEntity entity)
        {
            return new PatientModel(
                entity.Id,
                entity.Name,
                entity.BirthDate,
                entity.Sus.Value,
                entity.Cpf.Value,
                entity.Rg.Value,
                entity.Phone.Value,
                new AddressModel(
                    entity.AddressEntity.Id,
                    entity.AddressEntity.Cep.Value,
                    entity.AddressEntity.Street,
                    entity.AddressEntity.City,
                    entity.AddressEntity.Number
                    ),
                new EmergencyContactDetailsModel(
                    entity.EmergencyContactDetailsEntity.Id,
                    entity.EmergencyContactDetailsEntity.Name,
                    entity.EmergencyContactDetailsEntity.Phone.Value,
                    entity.EmergencyContactDetailsEntity.Relationship.Value
                    ),
                entity.ServicesEntity?.Select(service => new ServiceModel(
                    
                )).ToList() ?? new List<ServiceModel>());
        }
    }
}
