using prontuario.Domain.Entities.Nursing;
using prontuario.WebApi.ResponseModels.Nursing;

namespace prontuario.WebApi.ResponseModels.Patient
{
    public class NursingResponseModel
    {
        public static List<NursingResponse> CreateGetAllNursingResponse(List<NursingEntity> entity)
        {
            return entity.Select(nursing => new NursingResponse(
                nursing.Id,
                nursing.NursingNote,
                nursing.PatientId)
                ).ToList();
        }
    }
}
