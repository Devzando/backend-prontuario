using prontuario.Domain.Entities.MedicalRecord;

namespace prontuario.Domain.Entities.Service;

public class ServiceEntityBuilder
{
    private long? _id;
    private bool _serviceStatus;
    private PatientEntity _patient = null!;
    private DateTime _serviceDate;
    private MedicalRecordEntity _medicalRecordEntity = null!;

    public ServiceEntityBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public ServiceEntityBuilder WithServiceStatus(bool serviceStatus)
    {
        _serviceStatus = serviceStatus;
        return this;
    }

    public ServiceEntityBuilder WithPatient(PatientEntity patient)
    {
        _patient = patient;
        return this;
    }

    public ServiceEntityBuilder WithServiceDate(DateTime serviceDate)
    {
        _serviceDate = serviceDate;
        return this;
    }

    public ServiceEntityBuilder WithMedicalRecordEntity(MedicalRecordEntity medicalRecordEntity)
    {
        _medicalRecordEntity = medicalRecordEntity;
        return this;
    }

    public ServiceEntity Build()
    {
        return new ServiceEntity(_id, _serviceStatus, _patient, _serviceDate, _medicalRecordEntity);
    }

}