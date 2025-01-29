using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.PatientExams;
using prontuario.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Infra.Gateways
{
    public class PatientExamRepositoryGateway(ProntuarioDbContext context) : IPatientExamGateway
    {
        public async Task<PatientExamsEntity?> GetById(long id)
        {
            return await context.PatientExams
                .Include(pe => pe.MedicalRecord)
                .FirstOrDefaultAsync(pe => pe.Id == id);
        }

        public async Task Save(PatientExamsEntity patientExam)
        {
            context.Update(patientExam);
            await context.SaveChangesAsync();
        }
    }

}
