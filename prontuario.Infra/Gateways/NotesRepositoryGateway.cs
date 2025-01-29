using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.Notes;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways;

public class NotesRepositoryGateway(ProntuarioDbContext context) : INotesGateway
{
    public async Task CreateNote(NotesEntity notesEntity)
    {
        context.Notes.Add(notesEntity);
        await context.SaveChangesAsync();
    }

    public async Task<List<NotesEntity>?> GetNotesByPatient(long patientId)
    {
        return await context.Notes
            .Include(u => u.User)
            .Include(p => p.Patient)
            .Where(x => x.PatientId == patientId).ToListAsync();
    }

    public async Task<long> GetNotesCountByPatient(long patientId)
    {
        return await context.Notes.CountAsync(x => x.PatientId == patientId);
    }
}
