using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserId { get; set; }  // it could be teacher or student id or etc.

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Role { get; set; }  // "Student", "Admin", etc.
    }
}
