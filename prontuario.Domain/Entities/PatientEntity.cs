using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities
{
    public class PatientEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public SUS Sus { get; private set; } = null!;
        public CPF Cpf { get; private set; } = null!;
        public RG Rg { get; private set; } = null!;
        public Phone Phone { get; private set; } = null!;
        public AddressEntity Address { get; private set; } = null!;
        public EmergencyContactDetailsEntity EmergencyContatcDetails { get; private set; } = null!;
        public ICollection<ServiceEntity> Services { get; private set; } = null!;
        public PatientEntity() { }
        public PatientEntity(
            Guid id,
            string name,
            DateTime dateOfBirth, 
            SUS sus, 
            CPF cpf, 
            RG rg, 
            Phone phone, 
            AddressEntity address,
            EmergencyContactDetailsEntity emergencyContactDetails)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.Address = address;
            this.EmergencyContatcDetails = emergencyContactDetails;
        }
        public PatientEntity(
            string name,
            DateTime dateOfBirth,
            SUS sus,
            CPF cpf,
            RG rg,
            Phone phone,
            AddressEntity address,
            EmergencyContactDetailsEntity emergencyContactDetails)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.Address = address;
            this.EmergencyContatcDetails = emergencyContactDetails;
        }
    }
}
