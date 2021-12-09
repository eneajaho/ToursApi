using System;
using System.ComponentModel.DataAnnotations;
using ToursApi.Entities;

namespace ToursApi.DTOs.User
{
    public class UserCreateDto
    {
        [Required] public string Name { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "Please provide a correct email address.")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 30 characters")]
        public string Password { get; set; } = null!;

        [Required] public Role Role { get; set; }
        [Required] public string ImageUrl { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
    }
}