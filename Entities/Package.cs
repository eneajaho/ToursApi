namespace ToursApi.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}