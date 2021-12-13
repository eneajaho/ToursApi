using System.ComponentModel.DataAnnotations;

namespace ToursApi.DTOs.User
{
    public class SelfUserUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        
        [Required]
        [EmailAddress(ErrorMessage = "Please provide a correct email address.")]
        public string? Email { get; set; } = null!;
        public string? ImageUrl { get; set; } = null!;
        
        [StringLength(30, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 30 characters")]
        public string Password { get; set; } = null!;
    }
}