using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PokemonWebApplication.Context;
using PokemonWebApplication.Models;

using System.Linq;
using System.Threading.Tasks;

namespace PokemonWebApplication.Controllers
{
    public class MestrePokemonsController : Controller
    {
        private readonly PokemonDbContext _context;

        public MestrePokemonsController(PokemonDbContext context)
        {
            _context = context;
        }

        // GET: MestrePokemons
        public async Task<IActionResult> Index()
        {
            return View(await _context.MestrePokemon.ToListAsync());
        }

        // GET: MestrePokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mestrePokemon = await _context.MestrePokemon
                .FirstOrDefaultAsync(m => m.IdDoPokemon == id);
            if (mestrePokemon == null)
            {
                return NotFound();
            }

            return View(mestrePokemon);
        }

        // GET: MestrePokemons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MestrePokemons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoPokemon,Nome,Idade,CPF")] MestrePokemon mestrePokemon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mestrePokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mestrePokemon);
        }

        // GET: MestrePokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mestrePokemon = await _context.MestrePokemon.FindAsync(id);
            if (mestrePokemon == null)
            {
                return NotFound();
            }
            return View(mestrePokemon);
        }

        // POST: MestrePokemons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Idade,CPF")] MestrePokemon mestrePokemon)
        {
            if (id != mestrePokemon.IdDoPokemon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mestrePokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MestrePokemonExists(mestrePokemon.IdDoPokemon))
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
            return View(mestrePokemon);
        }

        // GET: MestrePokemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mestrePokemon = await _context.MestrePokemon
                .FirstOrDefaultAsync(m => m.IdDoPokemon == id);
            if (mestrePokemon == null)
            {
                return NotFound();
            }

            return View(mestrePokemon);
        }

        // POST: MestrePokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mestrePokemon = await _context.MestrePokemon.FindAsync(id);
            _context.MestrePokemon.Remove(mestrePokemon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MestrePokemonExists(int id)
        {
            return _context.MestrePokemon.Any(e => e.IdDoPokemon == id);
        }
    }
}
