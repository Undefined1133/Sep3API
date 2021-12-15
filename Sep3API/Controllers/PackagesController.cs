using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sep3API.Data;
using Sep3API.Models;
using Sep3API.Persistence;

namespace Sep3API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackagesController:ControllerBase
    {
         private IPackageService packageService;
         private CloudMemoryUserService _cloudMemoryUserService;
        public PackagesController(IPackageService packageService)
        {
            this.packageService=packageService;
            _cloudMemoryUserService = new CloudMemoryUserService();
        }
        [HttpGet]
        public async Task<ActionResult<IList<Package>>>
            GetPackages([FromQuery] int? packageId, [FromQuery] string? name, [FromQuery] string? location,
                [FromQuery]int? price,[FromQuery] int? review )
        {
            try
            {
                IList<Package> packages = await packageService.GetAllPackagesAsync();
                if (packageId != null)
                {
                    packages = packages.Where(p => p.ID == packageId).ToList();
                }
                if (name != null)
                {
                    packages = packages.Where(p => p.Name == name).ToList();
                }
                if (location != null)
                {
                    packages = packages.Where(p => p.Location == location).ToList();
                }
                if (price != null)
                {
                    packages = packages.Where(p => p.Price == price).ToList();
                }
                if (review != null)
                {
                    packages = packages.Where(p => p.Review == review).ToList();
                }

                return Ok(packages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("ID")]
        public async Task<ActionResult<Package>>
            GetPackageById( [FromQuery]int id)
        {
            try
            {
                Package package = await packageService.GetAsyncById(id);
              
                if(package != null)
                {
                    return Ok(package);
                }

                return StatusCode(404);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeletePackageAsync([FromRoute] int id)
        {
            try
            {
                await packageService.RemovePackageAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Package>> AddPackageAsync([FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Package added = await packageService.AddPackageAsync(package);
                return Created($"/{added.ID}", added); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        
        
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Package>> UpdatePackage([FromBody] Package package)
        {
            try
            {
                Package updatedPackage = await packageService.UpdatePackageAsync(package);
                return Ok(updatedPackage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}