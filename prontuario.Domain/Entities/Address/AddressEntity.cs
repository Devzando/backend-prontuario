using prontuario.Domain.Entities.Patient;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Address
{
    public class AddressEntity
    {
        public long Id { get; private set; }
        public CEP Cep { get; private set; }
        public string? Street { get; private set; }
        public string? City { get; private set; }
        public long? Number { get; private set; }
        public string? Neighborhood { get; private set; }
        public long PatientId { get; private set; }
        public PatientEntity Patient { get; private set; }
        public AddressEntity() { }
        public AddressEntity(long id, CEP cep, string? street, string? city, long? number, string? neighborhood)
        {
            this.Id = id;
            this.Cep = cep;
            this.Street = street;
            this.City = city;
            this.Number = number;
            this.Neighborhood = neighborhood;
        }
    }
}
