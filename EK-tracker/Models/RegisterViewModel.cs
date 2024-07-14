using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EK_tracker.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string UserName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
