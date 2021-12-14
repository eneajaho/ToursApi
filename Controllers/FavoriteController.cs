using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToursApi.Entities;
using ToursApi.Extensions;
using ToursApi.Services;

namespace ToursApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoriteController : ControllerBase
    {
        private readonly FavoriteService _favoriteService;

        public FavoriteController(FavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<List<Favorite>> GetAuthUserFavorites() =>
            await _favoriteService.GetUserFavorites(User.GetId());

        [HttpGet("{userId}")]
        public async Task<List<Favorite>> GetUserFavorites(int userId) =>
            await _favoriteService.GetUserFavorites(userId);

        [HttpGet("package/{packageId}")]
        public async Task<int> GetPackageFavoritesCount(int packageId) =>
            await _favoriteService.GetPackageFavoritesCount(packageId);

        [HttpPost("{packageId}")]
        public async Task<ActionResult> AddFavorite(int packageId)
        {
            var favoriteFromRepo = await _favoriteService.GetFavorite(packageId);
            
            if (favoriteFromRepo == null)
                return Ok(await _favoriteService.AddFavoritePackage(User.GetId(), packageId));

            return BadRequest("The package is already added to favorites.");
        }

        [HttpDelete("{packageId}")]
        public async Task<ActionResult> RemoveFavorite(int packageId)
        {
            var favoriteFromRepo = await _favoriteService.GetFavorite(packageId);

            if (favoriteFromRepo == null)
                return NotFound();

            if (favoriteFromRepo.UserId != User.GetId())
                return Unauthorized();

            await _favoriteService.RemoveFavoritePackage(favoriteFromRepo);

            return NoContent();
        }
    }
}