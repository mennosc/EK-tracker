using System.ComponentModel.DataAnnotations;

namespace EK_tracker.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
