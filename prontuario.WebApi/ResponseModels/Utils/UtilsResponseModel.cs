using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Utils;
using prontuario.WebApi.ResponseModels.Patient;

namespace prontuario.WebApi.ResponseModels.Utils;

public class UtilsResponseModel
{
    public static PagedResponse<List<PatientResponse>> CreateListPatientPagedResponse(
        PagedResult<List<PatientEntity>> pages, int pageNumber, int pageSize)
    {
        return new PagedResponse<List<PatientResponse>>(
            pages.Pages.Select(PatientResponseModel.CreateGetAllPatientResponse).ToList(),
            pages.TotalRecords,
            pageNumber,
            pageSize);
    }
}