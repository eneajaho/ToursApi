using System;

namespace ToursApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = "user"; // user, company, admin
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }

        public string? ImageUrl { get; set; } = null!;
    }
}