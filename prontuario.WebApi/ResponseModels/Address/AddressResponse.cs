namespace prontuario.WebApi.ResponseModels.Address;

public record AddressResponse(
    long? Id,
    string Cep,
    string City,
    string Street,
    long Number,
    string Neighborhood
    );