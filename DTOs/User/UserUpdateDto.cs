using System.ComponentModel.DataAnnotations;

namespace ToursApi.DTOs.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        
        [Required]
        [EmailAddress(ErrorMessage = "Please provide a correct email address.")]
        public string? Email { get; set; } = null!;
        public string? ImageUrl { get; set; } = null!;
    }
}