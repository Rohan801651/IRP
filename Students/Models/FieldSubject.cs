using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class FieldSubject
    {

        [Key]
        public int FieldSubjectID { get; set; }

        [ForeignKey("Fields")]
        public int FieldID { get; set; }

        [ForeignKey("StudentSubjects")]
        public int SubjectID { get; set; }

        // Navigation properties
        public virtual Fields? Field { get; set; }
        public virtual StudentSubjects? Subject { get; set; }
    }
}
