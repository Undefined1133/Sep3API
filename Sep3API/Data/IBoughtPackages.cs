using System.Collections.Generic;
using System.Threading.Tasks;
using Sep3API.Models;

namespace Sep3API.Data
{
    public interface IBoughtPackages
    {
        Task<List<BoughtPackages>> GetBoughtPackagesAsync();
        Task<BoughtPackages> AddBoughtPackageAsync(BoughtPackages package);
        Task  RemovePackageAsync(int boughtPackageId);
        Task<BoughtPackages> UpdateBoughtPackageAsync(BoughtPackages package);
       
        Task <BoughtPackages> GetAsyncById(int boughtPackageId);
    }
}