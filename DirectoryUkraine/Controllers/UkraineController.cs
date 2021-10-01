using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectoryUkraine.Models;
using Microsoft.EntityFrameworkCore;

namespace DirectoryUkraine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UkraineController : ControllerBase
    {
        UkraineContext db;

        public UkraineController(UkraineContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegion()  
        {
            return await db.Region.ToListAsync();
        }

        //Все города
        [HttpGet]
        [Route("City")]
        public async Task<ActionResult<IEnumerable<City>>> GetCity()
        {
            return await db.City.ToListAsync();
        }

        //Получение коллекции городов по региону
        [HttpGet]
        [Route("Cities/{id}")]
        public async Task<ActionResult<City>> GetCities(int id)
        {
            IEnumerable<City> cities = await db.City.Where(x => x.region_id == id).ToListAsync();
            if (cities == null)
                return NotFound();
            return new ObjectResult(cities);
        }

        //Определенный город по id
        [HttpGet]
        [Route("City/{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            City city = await db.City.FirstOrDefaultAsync(x => x.id == id);
            if (city == null)
                return NotFound();
            return new ObjectResult(city);
        }


        //[HttpPut]
        //[Route("City")]
        //public async Task<ActionResult<City>> Update(City city)
        //{
        //    if (city == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (!db.City.Any(x => x.id == city.id))
        //    {
        //        return NotFound();
        //    }

        //    db.City.Update(city);
        //    await db.SaveChangesAsync();
        //    return Ok(city);
        //}

        [HttpPost]
        [Route("Cities")]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            db.City.Add(city);
            await db.SaveChangesAsync();
            return Ok(city);
        }

        [HttpGet]
        [Route("District")]
        public async Task<ActionResult<IEnumerable<District>>> GetDistrict()
        {
            return await db.District.ToListAsync();
        }

        [HttpGet]
        [Route("District/{id}")]
        public async Task<ActionResult<District>> GetDistrictsById(int id)
        {
            IEnumerable<District> district = await db.District.Where(x => x.region_id == id).ToListAsync();
            if (district == null)
                return NotFound();
            return new ObjectResult(district);
        }

        [HttpPost]
        [Route("District")]
        public async Task<ActionResult<District>> PostDistrict(District district)
        {
            if (district == null)
            {
                return BadRequest();
            }

            db.District.Add(district);
            await db.SaveChangesAsync();
            return Ok(district);
        }

        [HttpGet]
        [Route("Distric/{id}")]
        public async Task<ActionResult<District>> GetOneDistric(int id)
        {
            District district = await db.District.FirstOrDefaultAsync(x => x.id == id);
            if (district == null)
                return NotFound();
            return new ObjectResult(district);
        }

        [HttpDelete]
        [Route("Cities/{id}/del")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            City city = db.City.FirstOrDefault(x => x.id == id);

            if (city == null) 
            {
                return NotFound();
            }

            db.City.Remove(city);
            await db.SaveChangesAsync();
            
            return Ok(city);
        }

        [HttpDelete]
        [Route("District/{id}/del")]
        public async Task<ActionResult<District>> DeleteDistrict(int id)
        {
            District district = db.District.FirstOrDefault(x => x.id == id);

            if (district == null)
            {
                return NotFound();
            }

            db.District.Remove(district);
            await db.SaveChangesAsync();

            return Ok(district);
        }

    }
}
