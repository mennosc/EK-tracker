using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EK_tracker.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
