using System.ComponentModel.DataAnnotations;

namespace Teachers.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string? TeacherName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string? TeacherEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string? TeacherQualification { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Contact number cannot be longer than 15 characters.")]
        public string? TeacherContact { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string? TeacherAddress { get; set; }

        [Required]
        public int ClassOfTeaching { get; set; }
    }
}
