using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sep3API.Data;
using BoughtPackages = Sep3API.Models.BoughtPackages;


namespace Sep3API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoughtPackagesController : ControllerBase
    {
        private IBoughtPackages BoughtPackagesService;

        public BoughtPackagesController(IBoughtPackages boughtPackages)
        {
            this.BoughtPackagesService = boughtPackages;
        }
        // GET
        [HttpGet]
        public async Task<ActionResult<List<BoughtPackages>>>
            GetPackages([FromQuery] int? packageId, [FromQuery] int? id,[FromQuery] int? userId)
        {
            try
            {
                List<BoughtPackages> boughtPackages = await BoughtPackagesService.GetBoughtPackagesAsync();
                if (id != null)
                {
                    boughtPackages = boughtPackages.Where(p => p.BoughtPackageId == id).ToList();
                }
                if (packageId != null)
                {
                    boughtPackages = boughtPackages.Where(p => p.PackageId == packageId).ToList();
                }
                if (userId != null)
                {
                    boughtPackages = boughtPackages.Where(p => p.UserId == userId).ToList();
                }
             

                return Ok(boughtPackages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult<BoughtPackages>> AddPackageAsync([FromBody] BoughtPackages boughtPackages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                BoughtPackages added = await BoughtPackagesService.AddBoughtPackageAsync(boughtPackages);
                return Created($"/{added.BoughtPackageId}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}