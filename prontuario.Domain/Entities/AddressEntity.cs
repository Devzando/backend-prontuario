using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities
{
    public class AddressEntity
    {
        public long Id { get; private set; }
        public CEP Cep { get; private set; } = null!;
        public string Street { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public long Number { get; private set; } = 0;
        public AddressEntity() { }
        public AddressEntity(long id, CEP cep, string street, string city, long number)
        {
            this.Id = id;
            this.Cep = cep;
            this.Street = street;
            this.City = city;
            this.Number = number;
        }

        public AddressEntity(CEP cep, string street, string city, long number)
        {
            this.Cep = cep;
            this.Street = street;
            this.City = city;
            this.Number = number;
        }
    }
}
