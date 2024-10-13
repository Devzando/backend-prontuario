using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities
{
    public class EmergencyContactDetailsEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public Relationship Relationship { get; private set; } = null!;
        public EmergencyContactDetailsEntity() { }

        public EmergencyContactDetailsEntity(Guid id, string name, string phone, Relationship relationship)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Relationship = relationship;
        }
    }
}
