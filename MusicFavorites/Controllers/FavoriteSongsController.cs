using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicFavorites.Data;
using MusicFavorites.Models;

namespace MusicFavorites.Controllers
{
    public class FavoriteSongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public FavoriteSongsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: FavoriteSongs
        public async Task<IActionResult> Index()
        {
            ViewData["scripts"] = new List<string>() {
                "getSongList",
                "addSong"
            };
            return View(await _context.FavoriteSong.ToListAsync());
        }

        // GET: FavoriteSongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteSong = await _context.FavoriteSong
                .FirstOrDefaultAsync(m => m.FavoriteSongId == id);
            if (favoriteSong == null)
            {
                return NotFound();
            }

            return View(favoriteSong);
        }

        // GET: FavoriteSongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavoriteSongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FavoriteSong song)
        {
            if (ModelState.IsValid)
            {
                FavoriteSong favoriteSong = new FavoriteSong() {
                    SongURL = $"http://localhost:5555/songs/{song.SongURL}",
                    SongTitle = song.SongTitle,
                    ApplicationUser = await GetCurrentUserAsync()
                };
                _context.Add(favoriteSong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        // GET: FavoriteSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteSong = await _context.FavoriteSong.FindAsync(id);
            if (favoriteSong == null)
            {
                return NotFound();
            }
            return View(favoriteSong);
        }

        // POST: FavoriteSongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoriteSongId,SongURL,ApplicationUserId")] FavoriteSong favoriteSong)
        {
            if (id != favoriteSong.FavoriteSongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteSong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteSongExists(favoriteSong.FavoriteSongId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteSong);
        }

        // GET: FavoriteSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteSong = await _context.FavoriteSong
                .FirstOrDefaultAsync(m => m.FavoriteSongId == id);
            if (favoriteSong == null)
            {
                return NotFound();
            }

            return View(favoriteSong);
        }

        // POST: FavoriteSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteSong = await _context.FavoriteSong.FindAsync(id);
            _context.FavoriteSong.Remove(favoriteSong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteSongExists(int id)
        {
            return _context.FavoriteSong.Any(e => e.FavoriteSongId == id);
        }
    }
}
