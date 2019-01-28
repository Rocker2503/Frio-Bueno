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
    public class DespachoLotesController : Controller
    {

        private readonly FrioBuenoContext _context;

        public DespachoLotesController(FrioBuenoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.LotesParaDespacho.ToListAsync());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var lote = await _context.LotesParaDespacho.SingleOrDefaultAsync(m => m.Id == id);
            if(lote == null)
            {
                return NotFound();
            }
            return View(lote);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var lote = await _context.LotesParaDespacho.SingleOrDefaultAsync(m => m.Id == id);

            _context.LotesParaDespacho.Remove(lote);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "LotesParaDespachos");
        }
    }
}