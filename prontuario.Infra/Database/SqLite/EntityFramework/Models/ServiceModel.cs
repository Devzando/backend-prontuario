using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models
{
    [Table("Services")]
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; private set; } = string.Empty;

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateService { get; private set; }

        [Required]
        public long PatientId { get; set; } 

        [ForeignKey("PatientId")]
        [Column("Patient_Id")]
        public PatientModel PatientModel { get; set; } = null!;
        public ServiceModel() { }
        public ServiceModel(long id, string name, DateTime dateService, PatientModel patientModel)
        {
            this.Id = id;
            this.Name = name;
            this.DateService = dateService;
            this.PatientModel = patientModel;
        }
        public ServiceModel(string name, DateTime dateService, PatientModel patientModel)
        {
            this.Name = name;
            this.DateService = dateService;
            this.PatientModel = patientModel;
        }
        public ServiceModel(long id, string name, DateTime dateService)
        {
            this.Id = id;
            this.Name = name;
            this.DateService = dateService;
        }
    }
    
}
