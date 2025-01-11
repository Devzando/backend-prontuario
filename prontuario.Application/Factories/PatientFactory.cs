using prontuario.Domain.Dtos.Patient;
using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Address;
using prontuario.Domain.Entities.EmergencyContactDetails;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Enums;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories
{
    public class PatientFactory
    {
        public static PatientEntity CreatePatient(CreatePatientDTO data)
        {
            return new PatientEntityBuilder()
                .WithName(data.Name)
                .WithSocialName(data.SocialName)
                .WithBirthDate(data.BirthDate)
                .WithSus(new SUS(data.Sus))
                .WithCpf(new CPF(data.Cpf))
                .WithRg(new RG(data.Rg))
                .WithPhone(new Phone(data.Phone))
                .WithMotherName(data.MotherName)
                .WithStatus(new PatientStatus(PatientStatusType.NO_SERVICE.ToString()))
                .WithAddress(new AddressEntityBuilder()
                    .WithCep(new CEP(data.Address?.Cep))
                    .WithCity(data.Address?.City)
                    .WithStreet(data.Address?.Street)
                    .WithNumber(data.Address?.Number)
                    .WithNeighborhood(data.Address?.Neighborhood)
                    .Build())
                .WithEmergencyContactDetails(new EmergencyContactDetailsEntityBuilder()
                    .WithName(data.EmergencyContactDetails?.Name)
                    .WithPhone(new Phone(data.EmergencyContactDetails?.Phone))
                    .WithRelationship(new Relationship(data.EmergencyContactDetails?.Relationship))
                    .Build())
                .Build();
        }

        public static PatientEntity CreatePatient(PatientEntity patient)
        {
            return new PatientEntityBuilder()
                .WithId(patient.Id)
                .WithName(patient.Name)
                .WithSocialName(patient.SocialName)
                .WithBirthDate(patient.BirthDate)
                .WithSus(patient.Sus)
                .WithCpf(patient.Cpf)
                .WithRg(patient.Rg)
                .WithPhone(patient.Phone)
                .WithMotherName(patient.MotherName)
                .WithStatus(new PatientStatus(PatientStatusType.IN_SERVICE.ToString()))
                .WithAddress(new AddressEntityBuilder()
                    .WithId(patient.AddressEntity.Id)
                    .WithCep(patient.AddressEntity.Cep)
                    .WithCity(patient.AddressEntity.City)
                    .WithStreet(patient.AddressEntity.Street)
                    .WithNumber(patient.AddressEntity.Number)
                    .WithNeighborhood(patient.AddressEntity.Neighborhood)
                    .Build())
                .WithEmergencyContactDetails(new EmergencyContactDetailsEntityBuilder()
                    .WithId(patient.EmergencyContactDetailsEntity.Id)
                    .WithName(patient.EmergencyContactDetailsEntity.Name)
                    .WithPhone(patient.EmergencyContactDetailsEntity.Phone)
                    .WithRelationship(patient.EmergencyContactDetailsEntity.Relationship)
                    .Build())
                .Build();
        }
        
        public static PatientEntity CreatePatient(UpdatePatientDTO data)
        {
            return new PatientEntityBuilder()
                .WithName(data.Name)
                .WithSocialName(data.SocialName)
                .WithBirthDate(data.BirthDate)
                .WithSus(new SUS(data.Sus))
                .WithCpf(new CPF(data.Cpf))
                .WithRg(new RG(data.Rg))
                .WithPhone(new Phone(data.Phone))
                .WithMotherName(data.MotherName)
                .WithStatus(new PatientStatus(data.Status))
                .WithAddress(new AddressEntityBuilder()
                    .WithCep(new CEP(data.Address.Cep))
                    .WithCity(data.Address.City)
                    .WithStreet(data.Address.Street)
                    .WithNumber(data.Address.Number)
                    .WithNeighborhood(data.Address.Neighborhood)
                    .Build())
                .WithEmergencyContactDetails(new EmergencyContactDetailsEntityBuilder()
                    .WithName(data.EmergencyContactDetails.Name)
                    .WithPhone(new Phone(data.EmergencyContactDetails.Phone))
                    .WithRelationship(new Relationship(data.EmergencyContactDetails.Relationship))
                    .Build())
                .Build();
        }
    }
}
