using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EK_tracker.Models
{
    public class UserRegistrationModel : IdentityUser
    {
        [Key]
<<<<<<< HEAD
        public string FirstName { get; set; }
        public string LastName { get; set; }
=======
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
>>>>>>> parent of d4f299b (Delete ugly GroupProcessor and MatchProcessor)
        public string Password { get; set; }
    }
}
