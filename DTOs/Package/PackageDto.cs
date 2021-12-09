using ToursApi.DTOs.User;

namespace ToursApi.DTOs.Package
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDto User { get; set; }
    }
}