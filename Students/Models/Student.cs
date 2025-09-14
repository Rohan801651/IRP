using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public int RollNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string? StudentName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Contact cannot be longer than 15")]
        public string? StudentContact { get; set; }

        [Required]
        public DateTime? DateOfRegistration { get; set; }



        [ForeignKey("StudentClasses")]
        public int ClassID { get; set; }

        [ForeignKey("Fields")]
        public int? FieldID { get; set; } // Made nullable to support classes without fields

        // Navigation properties
        public virtual StudentClasses? Class { get; set; }
        public virtual Fields? Field { get; set; }
    }
}