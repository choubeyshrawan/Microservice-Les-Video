using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.IRepo;
using PlatformService.Models;

namespace PlatformService.RepositoryImplementation
{
    public class PlatformRepository : IPlatformRepo
    {
        private readonly ApplicationDbContext _context;

        public PlatformRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Create(Platform platform)
        {
            if (platform==null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            else
            {
                _context.AddAsync(platform);
            }
        }

        public void Delete(Platform platform)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Platform>> GetAll()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task<Platform> GetById(int id)
        {
            return await _context.Platforms.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(Platform platform)
        {
            throw new NotImplementedException();
        }
    }
}