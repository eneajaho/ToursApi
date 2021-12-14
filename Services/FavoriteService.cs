using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToursApi.Entities;

namespace ToursApi.Services
{
    public class FavoriteService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FavoriteService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Favorite>> GetUserFavorites(int userId) =>
            await _context.Favorites
                .Where(x => x.UserId == userId)
                .Include(x => x.Package)
                .ToListAsync();
        
        public async Task<Favorite?> GetFavorite(int favoriteId) =>
            await _context.Favorites
                .Where(x => x.Id == favoriteId)
                .Include(x => x.Package)
                .SingleOrDefaultAsync();
        
        public async Task<bool> AddFavoritePackage(int userId, int packageId)
        {
            var favorite = new Favorite()
            {
                PackageId = packageId,
                UserId = userId
            };

            await _context.Favorites.AddAsync(favorite);
            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<bool> RemoveFavoritePackage(Favorite favorite)
        {
            _context.Favorites.Remove(favorite);
            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<int> GetPackageFavoritesCount(int packageId) =>
            await _context.Favorites.Where(x => x.PackageId == packageId).CountAsync();
    }
}