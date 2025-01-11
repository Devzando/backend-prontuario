using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.EmergencyContactDetails
{
    public class EmergencyContactDetailsEntity
    {
        public long? Id { get; private set; }
        public string? Name { get; private set; }
        public Phone? Phone { get; private set; }
        public Relationship? Relationship { get; private set; }
        public EmergencyContactDetailsEntity() { }

        public EmergencyContactDetailsEntity(long? id, string? name, Phone? phone, Relationship? relationship)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Relationship = relationship;
        }
    }
}
