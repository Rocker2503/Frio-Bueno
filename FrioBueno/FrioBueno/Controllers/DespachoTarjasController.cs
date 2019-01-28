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
    public class DespachoTarjasController : Controller
    {

        private readonly FrioBuenoContext _context;

        public DespachoTarjasController(FrioBuenoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductosParaDespacho.ToListAsync());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var producto = await _context.ProductosParaDespacho.SingleOrDefaultAsync(m => m.Id == id);
            if( producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.ProductosParaDespacho.SingleOrDefaultAsync(m => m.Id == id);

            _context.ProductosParaDespacho.Remove(producto);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "DespachoTarjas");
        }

        public bool ProductExists(int id)
        {
            return _context.ProductosParaDespacho.Any(m => m.Id == id);
        }
    }
}