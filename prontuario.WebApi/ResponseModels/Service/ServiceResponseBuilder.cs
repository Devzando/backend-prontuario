using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.MedicalRecord;

namespace prontuario.WebApi.ResponseModels.Service;

public class ServiceResponseBuilder
{
    private long _id { get; set; }
    private DateTime _serviceDate { get; set; }
    private string? _serviceStatus { get; set; }
    private MedicalRecordResponse? _medicalRecordResponse { get; set; }

    public ServiceResponseBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public ServiceResponseBuilder WithServiceDate(DateTime serviceDate)
    {
        _serviceDate = serviceDate;
        return this;
    }

    public ServiceResponseBuilder WithServiceStatus(string? serviceStatus)
    {
        _serviceStatus = serviceStatus;
        return this;
    }

    public ServiceResponseBuilder WithMedicalRecordResponse(MedicalRecordResponse? medicalRecordResponse)
    {
        _medicalRecordResponse = medicalRecordResponse;
        return this;
    }

    public ServiceResponse Build()
    {
        return new ServiceResponse(_id, _serviceDate, _serviceStatus, _medicalRecordResponse);
    }
}