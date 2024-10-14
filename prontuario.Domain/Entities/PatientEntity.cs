using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities
{
    public class PatientEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public SUS Sus { get; private set; } = null!;
        public CPF Cpf { get; private set; } = null!;
        public RG Rg { get; private set; } = null!;
        public Phone Phone { get; private set; } = null!;
        public AddressEntity AddressEntity { get; private set; } = null!;
        public EmergencyContactDetailsEntity EmergencyContactDetailsEntity { get; private set; } = null!;
        public ICollection<ServiceEntity> ServicesEntity { get; private set; } = null!;
        public PatientEntity() { }
        public PatientEntity(
            long id,
            string name,
            DateTime dateBirth, 
            SUS sus, 
            CPF cpf, 
            RG rg, 
            Phone phone, 
            AddressEntity addressEntity,
            EmergencyContactDetailsEntity emergencyContactDetailsEntity,
            ICollection<ServiceEntity> serviceEntities)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDate = dateBirth;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.AddressEntity = addressEntity;
            this.EmergencyContactDetailsEntity = emergencyContactDetailsEntity;
            this.ServicesEntity = serviceEntities;
        }
        public PatientEntity(
            string name,
            DateTime dateBirth,
            SUS sus,
            CPF cpf,
            RG rg,
            Phone phone,
            AddressEntity addressEntity,
            EmergencyContactDetailsEntity emergencyContactDetailsEntity)
        {
            this.Name = name;
            this.BirthDate = dateBirth;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.AddressEntity = addressEntity;
            this.EmergencyContactDetailsEntity = emergencyContactDetailsEntity;
        }
    }
}
