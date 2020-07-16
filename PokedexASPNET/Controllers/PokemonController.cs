using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedexASPNET.Models;

namespace PokedexASPNET.Controllers
{
    public class PokemonController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Pokemon Pokemon { get; set; }

        public PokemonController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var pokemonList = _db.Pokemons.ToList();
            return View(pokemonList);
        }

        public IActionResult Pokelist()
        {
            var pokemonList = _db.Pokemons.ToList();
            return View(pokemonList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var pokemonFromDb = await _db.Pokemons.FirstOrDefaultAsync(u => u.Id == id);
            if (pokemonFromDb == null)
            {
                return Json(new { success = false, message = "Error" });
            }
            return View(pokemonFromDb);
        }

        public async Task<IActionResult> UpdateCaught(int id)
        {
            var pokemonFromDb = await _db.Pokemons.FirstOrDefaultAsync(u => u.Id == id);
            if (pokemonFromDb == null)
            {
                return Json(new { success = false, message = "Error while updating" });
            }
            pokemonFromDb.Caught = !pokemonFromDb.Caught;
            await _db.SaveChangesAsync();
            //return Json(new { success = true, message = "Update Successful" });
            return RedirectToAction("Index");
        }

        public IActionResult Upsert(int? id)
        {
            Pokemon = new Pokemon();
            if( id == null)
            {
                //create
                return View(Pokemon);
            }
            //update
            Pokemon = _db.Pokemons.FirstOrDefault(u => u.Id == id);
            if( Pokemon == null )
            {
                return NotFound();
            }
            return View(Pokemon);
        }

        #region API Calls
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if(ModelState.IsValid)
            {
                if( Pokemon.Id == 0 )
                {
                    //create
                    _db.Pokemons.Add(Pokemon);
                }
                else
                {
                    _db.Pokemons.Update(Pokemon);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Pokemon);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCaught()
        {
            var pokemonFromDb = await _db.Pokemons.FirstOrDefaultAsync(u => u.Id == id);
            if (pokemonFromDb == null)
            {
                return Json(new { success = false, message = "Error while updating" });
            }
            pokemonFromDb.Caught = !pokemonFromDb.Caught;
            await _db.SaveChangesAsync();
            //return Json(new { success = true, message = "Update Successful" });
            return RedirectToAction("Index");
        }*/

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Pokemons.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var pokemonFromDb = await _db.Pokemons.FirstOrDefaultAsync(u => u.Id == id);
            if( pokemonFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Pokemons.Remove(pokemonFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
