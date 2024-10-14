using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities
{
    public class EmergencyContactDetailsEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Phone Phone { get; private set; } = null!;
        public Relationship Relationship { get; private set; } = null!;
        public EmergencyContactDetailsEntity() { }

        public EmergencyContactDetailsEntity(long id, string name, Phone phone, Relationship relationship)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Relationship = relationship;
        }
        public EmergencyContactDetailsEntity(string name, Phone phone, Relationship relationship)
        {
            this.Name = name;
            this.Phone = phone;
            this.Relationship = relationship;
        }
    }
}
