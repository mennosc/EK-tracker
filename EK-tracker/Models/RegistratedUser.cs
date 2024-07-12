using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EK_tracker.Models
{
    public class RegistratedUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
    }
}
