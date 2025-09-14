using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class ClassSubject
    {
        // Composite key will be configured in the DbContext using Fluent API

        [Key]
        public int ClassSubjectID { get; set; }

        [ForeignKey("StudentClasss")]
        public int ClassID { get; set; }

        [ForeignKey("StudentSubjects")]
        public int SubjectID { get; set; }

        // Navigation properties
        public virtual StudentClasses? Class { get; set; }
        public virtual StudentSubjects? Subject { get; set; }
    }
}
