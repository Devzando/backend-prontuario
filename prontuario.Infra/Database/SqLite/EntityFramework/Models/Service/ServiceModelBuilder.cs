using prontuario.Infra.Database.SqLite.EntityFramework.Models.MedicalRecord;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;

public class ServiceModelBuilder
{
    private long? _id;
    private string _serviceStatus = string.Empty;
    private DateTime _serviceDate;
    private PatientModel _patient = null!;
    private MedicalRecordModel? _medicalRecordModel;

    public ServiceModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public ServiceModelBuilder WithServiceStatus(string serviceStatus)
    {
        _serviceStatus = serviceStatus;
        return this;
    }

    public ServiceModelBuilder WithServiceDate(DateTime serviceDate)
    {
        _serviceDate = serviceDate;
        return this;
    }

    public ServiceModelBuilder WithMedicalRecordModel(MedicalRecordModel? medicalRecordModel)
    {
        _medicalRecordModel = medicalRecordModel;
        return this;
    }

    public ServiceModelBuilder WithPatient(PatientModel patient)
    {
        _patient = patient;
        return this;
    }

    public ServiceModel Build()
    {
        return new ServiceModel(
            _id,
            _serviceStatus,
            _serviceDate,
            _patient,
            _medicalRecordModel
        );
    }
}