using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrioBueno.Models;
using System.Data.SqlClient;

namespace FrioBueno.Controllers
{
    public class DetalleCargasController : Controller
    {
        private readonly FrioBuenoContext _context;

        public DetalleCargasController(FrioBuenoContext context)
        {
            _context = context;
        }

        // GET: DetalleCargas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetalleCarga.ToListAsync());
        }

        // GET: DetalleCargas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalleCargas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarga,Producto,Envase,KgEnvase,FolioExterno")] DetalleCarga detalleCarga)
        {
            var carga = _context.Carga.Where(m => m.Id == detalleCarga.IdCarga).FirstOrDefault();
            int cantidadUS = Convert.ToInt32(carga.CantidadUS);
            
            var detallesCarga = _context.DetalleCarga.Where(dc => dc.IdCarga == carga.Id).ToList();

            int cantDetalle = detallesCarga.Capacity;
            if(cantidadUS > cantDetalle)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(detalleCarga);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Clientes");
                }
            }
            return RedirectToAction("Index", "Clientes");
        }

        // GET: DetalleCargas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarga = await _context.DetalleCarga.SingleOrDefaultAsync(m => m.Id == id);
            if (detalleCarga == null)
            {
                return NotFound();
            }
            return View(detalleCarga);
        }

        // POST: DetalleCargas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCarga,Producto,Envase,KgEnvase,FolioExterno")] DetalleCarga detalleCarga)
        {
            if (id != detalleCarga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCarga);
                    await _context.SaveChangesAsync();

                    _context.Database.ExecuteSqlCommand("DELETE FROM Producto WHERE FolioInterno = @id",
                        new SqlParameter("@id", id));
                    await _context.SaveChangesAsync();

                    var carga = _context.Carga.Where(c => c.Id == detalleCarga.IdCarga).FirstOrDefault();
                    int idCliente = Convert.ToInt32(carga.IdCliente);

                    var cliente = _context.Cliente.Where(c => c.Id == idCliente).FirstOrDefault();
                    int NumGuia = Convert.ToInt32(cliente.NumGuia);

                    _context.Database.ExecuteSqlCommand("Insert into Producto Values(@NumGuia, @FolioExterno, @FolioInterno, @Nombre, @Envase)",
                    new SqlParameter("NumGuia", NumGuia),
                    new SqlParameter("FolioExterno", detalleCarga.FolioExterno),
                    new SqlParameter("FolioInterno", detalleCarga.Id),
                    new SqlParameter("Nombre", detalleCarga.Producto),
                    new SqlParameter("Envase", detalleCarga.Envase)
                    );

                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCargaExists(detalleCarga.Id))
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
            return View(detalleCarga);
        }

        // GET: DetalleCargas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarga = await _context.DetalleCarga
                .SingleOrDefaultAsync(m => m.Id == id);
            if (detalleCarga == null)
            {
                return NotFound();
            }

            return View(detalleCarga);
        }

        // POST: DetalleCargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleCarga = await _context.DetalleCarga.SingleOrDefaultAsync(m => m.Id == id);
            _context.DetalleCarga.Remove(detalleCarga);
            await _context.SaveChangesAsync();

            _context.Database.ExecuteSqlCommand("DELETE FROM Producto WHERE FolioInterno = @id",
                new SqlParameter("@id", id));
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCargaExists(int id)
        {
            return _context.DetalleCarga.Any(e => e.Id == id);
        }
    }
}
