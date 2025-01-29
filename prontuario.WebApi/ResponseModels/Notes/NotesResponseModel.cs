using prontuario.Domain.Entities.Notes;

namespace prontuario.WebApi.ResponseModels.Notes
{
    public class NotesResponseModel
    {
        public static List<NotesResponse> CreateGetAllNotesResponse(List<NotesEntity> entity)
        {
            return entity.Select(notes => new NotesResponse(
                notes.Id,
                notes.User.Name,
                notes.User.Position.Value,
                notes.Description,
                notes.CreatedAt)
                ).ToList();
        }
    }
}
