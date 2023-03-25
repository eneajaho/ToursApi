namespace ToursApi.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Duration { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}