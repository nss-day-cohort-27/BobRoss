using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicFavorites.Data;
using MusicFavorites.Models;

/*
    This controller was scaffolded:

    dotnet aspnet-codegenerator controller
        -name FavoriteSongsController
        -actions
        -m FavoriteSong
        -dc ApplicationDbContext
        -outDir Controllers
 */

namespace MusicFavorites.Controllers
{
    public class FavoriteSongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoriteSongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FavoriteSongs
        public async Task<IActionResult> Index()
        {
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoriteSongId,SongURL,ApplicationUserId")] FavoriteSong favoriteSong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteSong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteSong);
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
