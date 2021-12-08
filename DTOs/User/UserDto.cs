namespace ToursApi.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; }
        // public DateTime LastActive { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}