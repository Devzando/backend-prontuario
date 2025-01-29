using prontuario.Domain.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Gateways;

public interface INotesGateway
{
    Task CreateNote(NotesEntity notesEntity);
    Task<List<NotesEntity>?> GetNotesByPatient(long patientId);
    Task<long> GetNotesCountByPatient(long patientId);
}
