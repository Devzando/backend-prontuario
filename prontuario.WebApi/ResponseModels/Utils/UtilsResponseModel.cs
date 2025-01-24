using prontuario.Domain.Entities.Nursing;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.Enums;
using prontuario.Domain.Utils;
using prontuario.Domain.ValuesObjects;
using prontuario.WebApi.ResponseModels.Nursing;
using prontuario.WebApi.ResponseModels.Patient;
using prontuario.WebApi.ResponseModels.Service;

namespace prontuario.WebApi.ResponseModels.Utils;

public class UtilsResponseModel
{
    public static PagedResponse<List<PatientResponse>> CreateFindAllListPatientPagedResponse(
        PagedResult<List<PatientEntity>?> data, int pageNumber, int pageSize)
    {
        var patientResponses = data.Pages!
            .Select(PatientResponseModel.CreateGetAllPatientResponse)
            .ToList();

        return new PagedResponse<List<PatientResponse>>(
            patientResponses,
            data.TotalRecords,
            pageNumber,
            pageSize);
    }

    public static PagedResponse<List<NursingResponse>> CreateFindAllListNursingPagedResponse(
        PagedResult<List<NursingEntity>?> data, int pageNumber, int pageSize)
    {
        var NursingResponses = data.Pages
        .Select(nursing => new NursingResponse(
            nursing.Id,
            nursing.NursingNote,
            nursing.PatientId))
        .ToList();

        return new PagedResponse<List<NursingResponse>>(
        NursingResponses,
        data.TotalRecords,
        pageNumber,
        pageSize);
    }

    public static PagedResponse<List<ServiceResponse>> CreateFindAllServicesByPatientId(
        PagedResult<List<ServiceEntity>?> data, int pageNumber, int pageSize)
    {
        if (data.Pages!.Count == 0)
            return new PagedResponse<List<ServiceResponse>>(
                [],
                0,
                pageNumber,
                pageSize
            );
        
        var serviceResponses = data.Pages!
            .Select(ServiceResponseModel.CreateFindAllServiceByPatientId)
            .ToList();

        return new PagedResponse<List<ServiceResponse>>(
            serviceResponses,
            data.TotalRecords,
            pageNumber,
            pageSize
            );
    }
}