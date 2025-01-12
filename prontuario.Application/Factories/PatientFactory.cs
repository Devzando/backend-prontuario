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
                .WithEmergencyContactDetails(data.EmergencyContactDetails.Select(em => new EmergencyContactDetailsEntityBuilder()
                        .WithName(em.Name)
                        .WithPhone(new Phone(em.Phone))
                        .WithRelationship(new Relationship(em.Relationship))
                        .Build())
                    .ToList())
                .Build();
        }

        public static PatientEntity CreatePatientToUpdateStatus(PatientEntity patient)
        {
            patient.Status = patient.Status.Value == PatientStatusType.NO_SERVICE.ToString()
                ? new PatientStatus(PatientStatusType.IN_SERVICE.ToString()) 
                : new PatientStatus(PatientStatusType.NO_SERVICE.ToString());

            return patient;
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
                .WithEmergencyContactDetails(data.EmergencyContactDetails.Select(em => new EmergencyContactDetailsEntityBuilder()
                        .WithName(em.Name)
                        .WithPhone(new Phone(em.Phone))
                        .WithRelationship(new Relationship(em.Relationship))
                        .Build())
                    .ToList())
                .Build();
        }
    }
}
