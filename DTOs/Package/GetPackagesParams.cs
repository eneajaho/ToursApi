using ToursApi.Helpers;

namespace ToursApi.DTOs.Package
{
    public class GetPackagesParams : PaginationParams
    {
        public string? Name { get; set; }
        public int? UserId { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}