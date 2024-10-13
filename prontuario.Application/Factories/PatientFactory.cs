using prontuario.Domain.Dtos.Patient;
using prontuario.Domain.Entities;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories
{
    public class PatientFactory
    {
        public static PatientEntity CreatePatient(CreatePatientDTO data)
        {
            return new PatientEntity(
                data.Name,
                DateTime.Parse(data.BirthDate),
                new SUS(data.Sus),
                new CPF(data.Cpf), 
                new RG(data.Rg),
                new Phone(data.Phone),
                new AddressEntity(
                    new CEP(data.Address.Cep),
                    data.Address.Street,
                    data.Address.City,
                    data.Address.Number),
                new EmergencyContactDetailsEntity(
                    data.EmergencyContactDetails.Name,
                    new Phone(data.EmergencyContactDetails.Phone),
                    new Relationship(data.EmergencyContactDetails.Relationship))
                );
        }
    }
}
