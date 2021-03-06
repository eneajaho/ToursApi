using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ToursApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Role Role { get; set; } = Role.Admin; // user, company, admin
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }

        public string? ImageUrl { get; set; } = null!;

        public ICollection<Package> Packages { get; set; } = new Collection<Package>();
        public ICollection<Favorite> Favorites { get; set; } = new Collection<Favorite>();
    }
}