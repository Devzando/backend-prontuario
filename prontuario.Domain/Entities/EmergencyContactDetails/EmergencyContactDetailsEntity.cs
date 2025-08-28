using prontuario.Domain.Entities.Patient;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.EmergencyContactDetails
{
    public class EmergencyContactDetailsEntity
    {
        public long Id { get;  set; }
        public string? Name { get;  set; }
        public Phone Phone { get;  set; }
        public Relationship Relationship { get;  set; }
        public long PatientId { get;  set; }
        public PatientEntity Patient { get;  set; }
        public EmergencyContactDetailsEntity() { }

        public EmergencyContactDetailsEntity(long id, string? name, Phone phone, Relationship relationship)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Relationship = relationship;
        }
    }
}
