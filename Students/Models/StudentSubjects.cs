using System.ComponentModel.DataAnnotations;

namespace Students.Models
{
    public class StudentSubjects
    {

        [Key]
        public int SubjectID { get; set; }

        [Required]
        [StringLength(100)]
        public string? SubjectName { get; set; }

        // Navigation properties
        public virtual ICollection<FieldSubject> FieldSubjects { get; set; } = new List<FieldSubject>();
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();





    }
}
