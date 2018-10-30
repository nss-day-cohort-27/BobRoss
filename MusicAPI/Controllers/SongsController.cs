using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Models;
using Newtonsoft.Json;

/*
    This controller was scaffolded:
        dotnet aspnet-codegenerator controller
            -name SongsController
            -api
            -async
            -m Song
            -dc ApplicationDbContext
            -outDir Controllers
 */

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("JukeboxPolicy")]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public IEnumerable<Song> GetSong()
        {

            return _context.Song
                .Include(s => s.Genre)
                .Include(s => s.Artist)
                .Include(s => s.Album)
                ;

            /* Example of customizing the JSON response
            var dbSongs = _context.Song
                .Include(s => s.Genre)
                .Include(s => s.Artist)
                .Include(s => s.Album)
                ;

            var json = JsonConvert.SerializeObject(new { songs = dbSongs });
            return json;
             */
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = await _context.Song
                .Include(s => s.Genre)
                .Include(s => s.Artist)
                .Include(s => s.Album)
                .Where(s => s.SongId == id)
                .SingleAsync();

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutSong([FromRoute] int id, [FromBody] Song song)
        {
            /*
                If you need to get the Identity user that was created when you
                first generated your token, you can look it up with User.Identity.Name
             */
            var user = _context.User.Where(u => u.UserName == User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.SongId)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Songs
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostSong([FromBody] Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Song.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.SongId }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSong([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return Ok(song);
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.SongId == id);
        }
    }
}