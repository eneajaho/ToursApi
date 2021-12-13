using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToursApi.DTOs.Package;
using ToursApi.Entities;
using ToursApi.Extensions;
using ToursApi.Helpers;
using ToursApi.Services;

namespace ToursApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly PackageService _packageService;
        private readonly IMapper _mapper;

        public PackageController(DataContext context, PackageService packageService, IMapper mapper)
        {
            _context = context;
            _packageService = packageService;
            _mapper = mapper;
        }

        // GET: api/Package
        [HttpGet]
        public async Task<PagedData<PackageDto>> GetPackages([FromQuery] GetPackagesParams packagesParams) =>
            await _packageService.GetPackagesAsync(packagesParams);

        // GET: api/Package/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDto>> GetPackage(int id)
        {
            var package = await _packageService.PackageByIdAsync(id);

            if (package == null)
                return NotFound();

            return package;
        }

        // PUT: api/Package/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [AuthorizedRoles(Role.Admin)]
        public async Task<IActionResult> PutPackage(int id, PackageUpdateDto packageUpdateDto)
        {
            if (id != packageUpdateDto.Id)
                return BadRequest();

            var packageFromRepo = await _packageService.GetByIdAsync(id);

            if (packageFromRepo == null)
                return NotFound();

            if (packageFromRepo.UserId != User.GetId())
                return Unauthorized();

            _mapper.Map<PackageUpdateDto, Package>(packageUpdateDto, packageFromRepo);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Package
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AuthorizedRoles(Role.Admin)]
        public async Task<ActionResult<PackageDto>> PostPackage(PackageCreateDto packageCreateDto)
        {
            packageCreateDto.UserId = User.GetId();

            var packageToCreate = _mapper.Map<Package>(packageCreateDto);

            await _context.AddAsync(packageToCreate);
            await _context.SaveChangesAsync();

            var packageForReturn = await _packageService.PackageByIdAsync(packageToCreate.Id);

            return CreatedAtAction("GetPackage", new {id = packageForReturn!.Id}, packageForReturn);
        }

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
        [AuthorizedRoles(Role.Admin)]
        public async Task<IActionResult> DeletePackage(int id)
        {
            var user = await _context.Packages.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.Packages.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Package/5
        [HttpGet("user/{userId}")]
        public async Task<IEnumerable<PackageDto>?> GetUserPackage(int userId) =>
            await _packageService.GetPackagesByUserId(userId);
    }
}