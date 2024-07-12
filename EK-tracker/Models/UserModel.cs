using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EK_tracker.Models
{
    public class UserModel : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
