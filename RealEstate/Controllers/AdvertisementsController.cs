using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    [Produces("application/json")]
    [Route("api/Advertisements")]
    public class AdvertisementsController : Controller
    {
        private readonly Services.IAdvertisement _advertisementService;
        private readonly RealEstateContext _context;

        public AdvertisementsController(RealEstateContext context, Services.IAdvertisement advertisementService)
        {
            _advertisementService = advertisementService;
            _context = context;
        }
        [AllowAnonymous]
        // GET: api/Advertisements
        [HttpGet]
        public async Task<IActionResult> GetAdvertisements([FromQuery] int? userId)
        {
            IEnumerable<Advertisement> advertisements = _advertisementService.GetAdvertisements(userId);
            if (advertisements == null)
                return NoContent();
            return Ok(advertisements);
        }
        [AllowAnonymous]
        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdvertisement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advertisement = await _context.Advertisements.SingleOrDefaultAsync(m => m.ID == id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return Ok(advertisement);
        }
        [Authorize]
        // PUT: api/Advertisements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvertisement([FromRoute] int id, [FromBody] Advertisement advertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (!(int.Parse(User?.FindFirst("userId")?.Value)).Equals(id))
            //{
            //    return Unauthorized();
            //}

            Models.Advertisement updatedAdvertisement = await _advertisementService.UpdateAdvertisement(advertisement, id);
            if (updatedAdvertisement == null)
            {
                return NotFound();
            }

            return Ok(updatedAdvertisement);
        }

        [Authorize]
        // POST: api/Advertisements
        [HttpPost]
        public async Task<IActionResult> PostAdvertisement([FromBody] Advertisement advertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            advertisement.UserID = int.Parse(User?.FindFirst("userId")?.Value);
            Models.Advertisement createdAdvertisement = await _advertisementService.CreateAdvertisement(advertisement);
            if (createdAdvertisement != null)
            {
                return Ok(createdAdvertisement);
            }
            return BadRequest();
        }
        [Authorize]

        //// DELETE: api/Advertisements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvertisement([FromRoute] int id)
        {
           
            Models.Advertisement deletedAdvertisement= await _advertisementService.DeleteAdvertisement(id);

            if (deletedAdvertisement == null)
            {
                return NotFound();
            }
            return Ok(deletedAdvertisement);
        }

    }
}