using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.EmergencyContactDetails
{
    [Table("EmergencyContactDetails")]
    public class EmergencyContactDetailsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; private set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; private set; } = string.Empty;
        [Required]
        [MaxLength(15)]
        public string Phone { get; private set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Relationship { get; private set; } = string.Empty;

        [Required]
        public long PatientId { get; set; }

        [ForeignKey("PatientId")]
        [Column("Patient_Id")]
        public PatientModel PatientModel { get; private set; } = null!;

        public EmergencyContactDetailsModel() { }
        public EmergencyContactDetailsModel(
            long? id,
            string name,
            string phone,
            string relationship)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Relationship = relationship;
        }
    }
}
