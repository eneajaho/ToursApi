using ToursApi.DTOs.User;

namespace ToursApi.DTOs.Package
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public UserDto User { get; set; }
    }
}