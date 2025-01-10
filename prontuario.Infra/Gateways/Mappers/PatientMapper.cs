using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Address;
using prontuario.Domain.Entities.EmergencyContactDetails;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;
using prontuario.Infra.Database.SqLite.EntityFramework.Models;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Address;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.EmergencyContactDetails;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;

namespace prontuario.Infra.Gateways.Mappers
{
    public class PatientMapper
    {
        public static PatientEntity toEntity(PatientModel model)
        {
            return new PatientEntityBuilder()
                .WithId(model.Id)
                .WithName(model.Name)
                .WithSocialName(model.SocialName)
                .WithBirthDate(model.BirthDate)
                .WithSus(new SUS(model.Sus))
                .WithCpf(new CPF(model.Cpf))
                .WithRg(new RG(model.Rg))
                .WithPhone(new Phone(model.Phone))
                .WithMotherName(model.MotherName)
                .WithStatus(new PatientStatus(model.Status))
                .WithAddress(new AddressEntityBuilder()
                    .WithId(model.AddressModel.Id)
                    .WithCep(new CEP(model.AddressModel.Cep))
                    .WithCity(model.AddressModel.City)
                    .WithStreet(model.AddressModel.Street)
                    .WithNumber(model.AddressModel.Number)
                    .WithNeighborhood(model.AddressModel.Neighborhood)
                    .Build())
                .WithEmergencyContactDetails(new EmergencyContactDetailsEntityBuilder()
                    .WithId(model.EmergencyContactDetailsModel.Id)
                    .WithName(model.EmergencyContactDetailsModel.Name)
                    .WithPhone(new Phone(model.EmergencyContactDetailsModel.Phone))
                    .WithRelationship(new Relationship(model.EmergencyContactDetailsModel.Relationship))
                    .Build())
                .WithServices(model.ServicesModel.Select(service => new ServiceEntityBuilder()
                        .WithId(service.Id)
                        .WithServiceDate(service.ServiceDate)
                        .WithServiceStatus(new ServiceStatus(service.ServiceStatus))
                        .Build())
                    .ToList())
                .Build();
        }

        public static List<PatientEntity> toEntity(List<PatientModel> models)
        {
            return models.Select(model => toEntity(model)).ToList();
        }

        public static PatientModel toModel(PatientEntity entity)
        {
            return new PatientModelBuilder()
                .WithId(entity.Id)
                .WithName(entity.Name)
                .WithSocialName(entity.SocialName)
                .WithBirthDate(entity.BirthDate)
                .WithSus(entity.Sus.Value)
                .WithCpf(entity.Cpf.Value)
                .WithRg(entity.Rg.Value)
                .WithPhone(entity.Phone.Value)
                .WithMotherName(entity.MotherName)
                .WithStatus(entity.Status.Value)
                .WithAddress(new AddressModelBuilder()
                    .WithId(entity.AddressEntity.Id)
                    .WithCep(entity.AddressEntity.Cep.Value)
                    .WithCity(entity.AddressEntity.City)
                    .WithStreet(entity.AddressEntity.Street)
                    .WithNumber(entity.AddressEntity.Number)
                    .WithNeighborhood(entity.AddressEntity.Neighborhood)
                    .Build())
                .WithEmergencyContactDetails(new EmergencyContactDetailsModelBuilder()
                    .WithId(entity.EmergencyContactDetailsEntity.Id)
                    .WithName(entity.EmergencyContactDetailsEntity.Name)
                    .WithPhone(entity.EmergencyContactDetailsEntity.Phone.Value)
                    .WithRelationship(entity.EmergencyContactDetailsEntity.Relationship.Value)
                    .Build())
                .WithServices(entity.ServicesEntity.Select(services => new ServiceModelBuilder()
                        .WithId(services.Id)
                        .WithServiceDate(services.ServiceDate)
                        .WithServiceStatus(services.ServiceStatus.Value)
                        .Build())
                    .ToList())
                .Build();
        }
    }
}
