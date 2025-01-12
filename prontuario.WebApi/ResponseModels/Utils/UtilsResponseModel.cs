using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Enums;
using prontuario.Domain.Utils;
using prontuario.Domain.ValuesObjects;
using prontuario.WebApi.ResponseModels.Patient;

namespace prontuario.WebApi.ResponseModels.Utils;

public class UtilsResponseModel
{
    public static PagedResponse<List<PatientResponse>> CreateListPatientWithoutServicePagedResponse(
        PagedResult<List<PatientEntity>> data, int pageNumber, int pageSize)
    {
        return new PagedResponse<List<PatientResponse>>(
            data.Pages.Where(s => s.Status.Value == PatientStatusType.NO_SERVICE.ToString())
                .Select(PatientResponseModel.CreateGetAllPatientResponse).ToList(),
            data.TotalRecords,
            pageNumber,
            pageSize);
    }
    public static PagedResponse<List<PatientResponse>> CreateListPatientToScreeningPagedResponse(
        PagedResult<List<PatientEntity>> data, int pageNumber, int pageSize)
    {
        var patientResponses = data.Pages
            .Where(patient => patient.ServicesEntity != null && patient.ServicesEntity
                .Any(service => service.MedicalRecordEntity != null &&
                                service.MedicalRecordEntity.Status.Value == MedicalRecordStatusType.SCREENING.ToString()))
            .Select(PatientResponseModel.CreateGetAllPatientResponse)
            .ToList();

        return new PagedResponse<List<PatientResponse>>(
            patientResponses,
            data.TotalRecords,
            pageNumber,
            pageSize);
    }
    
    public static PagedResponse<List<PatientResponse>> CreateFindAllListPatientPagedResponse(
        PagedResult<List<PatientEntity>?> data, int pageNumber, int pageSize)
    {
        var patientResponses = data.Pages
            .Select(PatientResponseModel.CreateGetAllPatientResponse)
            .ToList();

        return new PagedResponse<List<PatientResponse>>(
            patientResponses,
            data.TotalRecords,
            pageNumber,
            pageSize);
    }
}