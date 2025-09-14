using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public enum FieldCategoryType
    {
        PreEng,
        PreMed,
        Inter_CS,
        Commerce,
        Bio,
        Matric_CS
    }

    public class Fields
    {
        [Key]
        public int FieldID { get; set; }

        [Required]
        public FieldCategoryType FieldName { get; set; }

        [ForeignKey("StudentClasses")]
        public int ClassID { get; set; }

        // Navigation properties
        public virtual StudentClasses? Class { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<FieldSubject> FieldSubjects { get; set; } = new List<FieldSubject>();
    }
}