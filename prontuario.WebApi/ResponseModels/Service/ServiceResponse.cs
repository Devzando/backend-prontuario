namespace prontuario.WebApi.ResponseModels.Service;

public record ServiceResponse(
    long Id,
    DateTime ServiceDate,
    string ServiceStatus
    );