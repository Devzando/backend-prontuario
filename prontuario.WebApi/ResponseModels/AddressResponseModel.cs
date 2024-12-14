using prontuario.Domain.ValuesObjects;

namespace prontuario.WebApi.ResponseModels
{
    public class AddressResponseModel
    {
        public CEP Cep { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public long Number { get; set; }
        public AddressResponseModel(CEP cep, string street, string city, long number)
        {
            Cep = cep;
            Street = street;
            City = city;
            Number = number;
        }
    }
}