using prontuario.Domain.ValuesObjects;

namespace prontuario.WebApi.ResponseModels
{
    public class PatientResponseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public SUS Sus { get; set; }
        public CPF Cpf { get; set; }
        public RG Rg { get; set; }
        public Phone Phone { get; set; }
        public AddressResponseModel Address { get; set; }
        public EmergencyContactDetailsResponseModel EmergencyContactDetails { get; set; }
        public PatientResponseModel(long id, string name, DateTime birthDate, SUS sus, CPF cpf, RG rg, Phone phone, AddressResponseModel address, EmergencyContactDetailsResponseModel emergencyContactDetails)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Sus = sus;
            Cpf = cpf;
            Rg = rg;
            Phone = phone;
            Address = address;
            EmergencyContactDetails = emergencyContactDetails;
        }
    }
}
