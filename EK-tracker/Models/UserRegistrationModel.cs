﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EK_tracker.Models
{
    public class UserRegistrationModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [PersonalData]
        public string? UserName { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
