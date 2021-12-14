using System.ComponentModel.DataAnnotations;

namespace ToursApi.Entities
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}