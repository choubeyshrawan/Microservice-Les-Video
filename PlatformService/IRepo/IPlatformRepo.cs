using PlatformService.Models;

namespace PlatformService.IRepo
{
    public interface IPlatformRepo
    {
        Task<bool> SaveChanges();
        Task<IEnumerable<Platform>> GetAll();

        //CRUD
        void Create(Platform platform);
        Task<Platform> GetById(int id);
        void Update(Platform platform);
        void Delete(Platform platform);
    }
}
