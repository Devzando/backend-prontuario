using prontuario.Domain.Entities.Patient;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Address
{
    public class AddressEntity
    {
        public long Id { get;  set; }
        public CEP Cep { get;  set; }
        public string? Street { get;  set; }
        public string? City { get;  set; }
        public long? Number { get;  set; }
        public string? Neighborhood { get;  set; }
        public long PatientId { get;  set; }
        public PatientEntity Patient { get;  set; }
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
