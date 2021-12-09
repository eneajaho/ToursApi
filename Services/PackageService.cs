using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ToursApi.DTOs.Package;
using ToursApi.Entities;
using ToursApi.Helpers;

namespace ToursApi.Services
{
    public class PackageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PackageService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedData<PackageDto>> GetPackagesAsync(GetPackagesParams packagesParams)
        {
            var packages = _context.Packages
                // we directly map to PackageDto so we don't query data we don't use
                .Include(x => x.User)
                .ProjectTo<PackageDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            if (!string.IsNullOrEmpty(packagesParams.Name))
                packages = packages.Where(x => x.Name.Contains(packagesParams.Name));
            
            if (packagesParams.UserId != null)
                packages = packages.Where(x => x.User.Id == packagesParams.UserId);

            // packages inherits from PaginationParams
            return await PagedData<PackageDto>.CreateAsync(packages, packagesParams);
        }

        public async Task<IEnumerable<PackageDto>?> GetPackagesByUserId(int userId) =>
            await _context.Packages
                .Where(u => u.UserId == userId)
                .ProjectTo<PackageDto>(_mapper.ConfigurationProvider)
                .IgnoreAutoIncludes()
                .ToListAsync();

        // Will be used when we need the whole Package entity (ex. on edit)
        public async Task<Package?> GetByIdAsync(int id) =>
            await _context.Packages
                .SingleOrDefaultAsync(u => u.Id == id);

        public async Task<PackageDto?> PackageByIdAsync(int id) =>
            await _context.Packages
                .Include(x => x.User)
                .ProjectTo<PackageDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(u => u.Id == id);
    }
}