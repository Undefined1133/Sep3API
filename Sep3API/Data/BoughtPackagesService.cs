using System.Collections.Generic;
using System.Threading.Tasks;
using Sep3API.Models;
using Sep3API.Persistence;

namespace Sep3API.Data
{
    public class BoughtPackagesService : IBoughtPackages
    {
        private SocketConnection _socketConnection;

        public BoughtPackagesService()
        {
            _socketConnection = new SocketConnection();
        }
        public async Task<List<BoughtPackages>> GetBoughtPackagesAsync()
        {
            return _socketConnection.ReceivingDataFromJavaAllBoughtPackages();
        }

        public async Task<BoughtPackages> AddBoughtPackageAsync(BoughtPackages boughtPackages)
        {
            return _socketConnection.SendBoughtPackageToDBAdd(boughtPackages);
        }

        public async Task RemovePackageAsync(int boughtPackageId)
        {
           await _socketConnection.SendingBoughtPackageIdDelete(boughtPackageId);
        }
        public async Task<BoughtPackages> UpdateBoughtPackageAsync(BoughtPackages boughtPackages)
        {
            return _socketConnection.SendBoughtPackageToDBUpdate(boughtPackages);
        }

        public async Task<BoughtPackages> GetAsyncById(int boughtPackageId)
        {
            return await _socketConnection.ReceivingDataFromJavaBoughtPackageById(boughtPackageId);
        }
    }
}