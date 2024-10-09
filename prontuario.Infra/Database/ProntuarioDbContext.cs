using Microsoft.EntityFrameworkCore;

namespace prontuario.Infra.Database
{
    public class ProntuarioDbContext : DbContext
    {
        public ProntuarioDbContext(DbContextOptions<ProntuarioDbContext> options) : base(options)
        {
        }
    }
}
