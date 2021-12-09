using ToursApi.Entities;
using ToursApi.Helpers;

namespace ToursApi.DTOs.User
{
    public class GetUsersParams : PaginationParams
    {
        public string? Name { get; set; }
        public Role? Role { get; set; }
    }
}