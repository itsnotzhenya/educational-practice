using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using webApi.Model;
using webApi.DAL;
namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FilmsController : Controller
    {
        FilmsRepository films;
        FilmContext db;

        public FilmsController(FilmContext context)
        {
            films = new FilmsRepository(context);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            var f = films.Get();
            return f;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var film = films.Get(id);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostFilm([FromBody] Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            films.Create(film);
            //_context.Film.Add(guitar);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuitar([FromRoute] int id, [FromBody] Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != film.Id)
            {
                return BadRequest();
            }

            //_context.Entry(film).State = EntityState.Modified;
            try
            {
                films.Update(film);
            }
            catch (Exception)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var film = await _context.Films.SingleOrDefaultAsync(m => m.FilmId == id);
            bool isDeleted = films.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok(true);
        }
        private bool FilmExists(int id)
        {
            return db.Films.Any(e => e.Id == id);
        }
    }
}
