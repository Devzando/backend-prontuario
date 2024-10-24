using prontuario.Domain.ValuesObjects;

namespace prontuario.WebApi.ResponseModels
{
    public class EmergencyContactDetailsResponseModel
    {
        public string Name { get; set; }
        public Phone Phone { get; set; }
        public Relationship Relationship { get; set; }
        public EmergencyContactDetailsResponseModel(string name, Phone phone, Relationship relationship)
        {
            Name = name;
            Phone = phone;
            Relationship = relationship;
        }
    }
}