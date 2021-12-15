using System.Collections.Generic;
using System.Threading.Tasks;
using Sep3API.Models;

namespace Sep3API.Data
{
    public interface IPackageService
    {
        Task<IList<Package>> GetAllPackagesAsync();
        Task<Package> AddPackageAsync(Package package);
        Task  RemovePackageAsync(int packageId);
        Task<Package> UpdatePackageAsync(Package package);
       
        Task <Package> GetAsyncById(int packageId);
    }
}