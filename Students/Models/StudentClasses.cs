using System.ComponentModel.DataAnnotations;

namespace Students.Models
{
    public class StudentClasses
    {
        [Key]
        public int ClassID { get; set; }

        [Required]
        public int ClassName { get; set; } // e.g., "9", "10", "11", "12"

        [Required]
        [StringLength(50)]
        public string? Level { get; set; } // e.g., "Matric", "Inter", "A-Level", etc.


        // Navigation properties
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Fields> Fields { get; set; } = new List<Fields>();
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
    }
}
