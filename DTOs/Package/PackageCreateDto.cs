namespace ToursApi.DTOs.Package
{
    public class PackageCreateDto
    {
        public string Name { get; set; } = null!;
        public int? UserId { get; set; }
    }
}