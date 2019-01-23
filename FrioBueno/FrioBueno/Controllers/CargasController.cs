using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrioBueno.Models;

namespace FrioBueno.Controllers
{
    public class CargasController : Controller
    {
        private readonly FrioBuenoContext _context;

        public CargasController(FrioBuenoContext context)
        {
            _context = context;
        }

        // GET: Cargas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carga.ToListAsync());
        }
       
        // GET: Cargas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Producto,TipoProducto,UnidadSoportante,CantidadUS,Envase,KgNeto,IdCliente")] Carga carga)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(carga);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Clientes");
            }
            return View(carga);
        }

        // GET: Cargas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carga = await _context.Carga.SingleOrDefaultAsync(m => m.Id == id);
            if (carga == null)
            {
                return NotFound();
            }
            return View(carga);
        }

        // POST: Cargas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producto,TipoProducto,UnidadSoportante,CantidadUS,Envase,KgNeto,IdCliente")] Carga carga)
        {
            if (id != carga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargaExists(carga.Id))
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
            return View(carga);
        }

        // GET: Cargas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carga = await _context.Carga
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carga == null)
            {
                return NotFound();
            }

            return View(carga);
        }

        // POST: Cargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carga = await _context.Carga.SingleOrDefaultAsync(m => m.Id == id);
            _context.Carga.Remove(carga);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Clientes");
        }

        private bool CargaExists(int id)
        {
            return _context.Carga.Any(e => e.Id == id);
        }
    }
}
