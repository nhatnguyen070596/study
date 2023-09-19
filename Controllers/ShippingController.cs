using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using study.Repositories;
using study.Repositories.Interface;
using study.Services.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingService shippingService;


        public ShippingController(IShippingService service)
        {
            shippingService = service;
        }
        // GET: /<controller>/
        [HttpPost("GetShip")]
        public async Task<IActionResult> GetShip(CheckoutModel model)
        {
            try
            {
                //var cachedTeamData = await redisCache.GetCacheData<List<Team>>("teams");

                //if (cachedTeamData != null)
                //{
                //    return Ok(cachedTeamData);
                //}
                var ship = shippingService.getShipping(model);

                //await redisCache.SetCacheData("teams", teams, DateTimeOffset.Now.AddMinutes(5.0));

                //await redisCache.RemoveData("teams");

                return Ok(ship);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

