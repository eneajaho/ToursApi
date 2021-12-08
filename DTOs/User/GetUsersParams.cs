using System;
using ToursApi.Helpers;

namespace ToursApi.DTOs.User
{
    public class GetUsersParams : PaginationParams
    {
        public string? Name { get; set; }
        public string? Role { get; set; }
    }
}