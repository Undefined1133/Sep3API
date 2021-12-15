using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using Sep3API.Models;
using Sep3API.Persistence;

namespace Sep3API.Data
{
    public class PackageService :IPackageService
    {
        private SocketConnection _socketConnection;

        public PackageService()
        {
            _socketConnection = new SocketConnection();
        }
        public async Task<IList<Package>> GetAllPackagesAsync()
        {
            return _socketConnection.ReceivingDataFromJavaPackages();
        }

        public async Task<Package> AddPackageAsync(Package package)
        {
             return _socketConnection.SendPackageToDBAdd(package);
        }
 
        public async Task RemovePackageAsync(int packageId)
        {
            await _socketConnection.SendingPackageIdDelete(packageId);
        }

        public  async Task<Package> UpdatePackageAsync(Package package)
        {
            return _socketConnection.SendPackageToDBUpdate(package);
        }

        public async Task<Package> GetAsyncById(int packageId)
        {
            return await _socketConnection.ReceivingDataFromJavaPackageById(packageId);
        }
    }
}