namespace prontuario.Domain.Entities
{
    public class ServiceEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public PatientEntity patientEntity { get; private set; } = null!;
        public DateTime DateService { get; private set; }
        public ServiceEntity() { }

        public ServiceEntity(long id, string name, PatientEntity patientEntity, DateTime DateService)
        {
            this.Id = id;
            this.Name = name;
            this.patientEntity = patientEntity;
            this.DateService = DateService;
        }
        public ServiceEntity(string name, PatientEntity patientEntity, DateTime DateService)
        {
            this.patientEntity = patientEntity;
            this.DateService = DateService;
        }
        public ServiceEntity(long id, string name, DateTime DateService)
        {
            this.Id = id;
            this.Name = name;
            this.DateService = DateService;
        }
    }
}
