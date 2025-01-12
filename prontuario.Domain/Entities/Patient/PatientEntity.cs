using prontuario.Domain.Entities.Address;
using prontuario.Domain.Entities.EmergencyContactDetails;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Patient
{
    public class PatientEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? SocialName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public SUS Sus { get; private set; } = null!;
        public CPF Cpf { get; private set; } = null!;
        public RG Rg { get; private set; } = null!;
        public Phone Phone { get; private set; } = null!;
        public string? MotherName { get; private set; }
        public PatientStatus Status { get; set; } = null!;
        public AddressEntity AddressEntity { get; private set; } = null!;
        public ICollection<EmergencyContactDetailsEntity> EmergencyContactDetailsEntity { get; private set; } = null!;
        public ICollection<ServiceEntity>? ServicesEntity { get; private set; }
        public PatientEntity() { }
        public PatientEntity(
            long id,
            string name,
            string? socialName,
            DateTime? dateBirth, 
            SUS sus, 
            CPF cpf, 
            RG rg, 
            Phone phone,
            string? motherName,
            PatientStatus status,
            AddressEntity addressEntity,
            ICollection<EmergencyContactDetailsEntity> emergencyContactDetailsEntity,
            ICollection<ServiceEntity>? serviceEntities)
        {
            this.Id = id;
            this.Name = name;
            this.SocialName = socialName;
            this.BirthDate = dateBirth;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.MotherName = motherName;
            this.Status = status;
            this.AddressEntity = addressEntity;
            this.EmergencyContactDetailsEntity = emergencyContactDetailsEntity;
            this.ServicesEntity = serviceEntities;
        }
    }
}
