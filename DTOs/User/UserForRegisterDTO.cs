using System;
using System.ComponentModel.DataAnnotations;

namespace ToursApi.DTOs.User
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto()
        {
            CreatedAt = DateTime.Now;
            LastActive = DateTime.Now;
        }

        [Required]
        [EmailAddress(ErrorMessage = "Please provide a correct email address.")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 30 characters")]
        public string Password { get; set; } = null!;

        [Required] public string Name { get; set; } = null!;
        [Required] public string Gender { get; set; } = null!;
        [Required] public DateTime Birthday { get; set; }
        [Required] public string KnownAs { get; set; } = null!;
        [Required] public string City { get; set; } = null!;
        [Required] public string Country { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
    }
}