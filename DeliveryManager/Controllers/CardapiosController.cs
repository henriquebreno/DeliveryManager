using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryManager.Configuration;
using DeliveryManager.Model;

namespace DeliveryManager.Controllers
{
    public class CardapiosController : Controller
    {
        private readonly Contexto _context;

        public CardapiosController(Contexto context)
        {
            _context = context;
        }

        // GET: Cardapios
        public async Task<IActionResult> Index()
        {
            return Json(await _context.Cardapio.ToListAsync());
        }

        // GET: Cardapios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapio
                .FirstOrDefaultAsync(m => m.Id_Cardapio == id);
            if (cardapio == null)
            {
                return NotFound();
            }

            return Json(cardapio);
        }

        // GET: Cardapios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cardapios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Preco,Nome,Descricao,Url,Id_Cardapio")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardapio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Json(cardapio);
        }

        // GET: Cardapios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapio.FindAsync(id);
            if (cardapio == null)
            {
                return NotFound();
            }
            return View(cardapio);
        }

        // PUT: Cardapios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Preco,Nome,Descricao,Url,Id_Cardapio")] Cardapio cardapio)
        {
            if (id != cardapio.Id_Cardapio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardapio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardapioExists(cardapio.Id_Cardapio))
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
            return View(cardapio);
        }

        // GET: Cardapios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapio
                .FirstOrDefaultAsync(m => m.Id_Cardapio == id);
            if (cardapio == null)
            {
                return NotFound();
            }

            return View(cardapio);
        }

        // POST: Cardapios/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardapio = await _context.Cardapio.FindAsync(id);
            _context.Cardapio.Remove(cardapio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardapioExists(int id)
        {
            return _context.Cardapio.Any(e => e.Id_Cardapio == id);
        }
    }
}
