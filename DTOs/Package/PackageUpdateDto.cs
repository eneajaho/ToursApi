namespace ToursApi.DTOs.Package
{
    public class PackageUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}