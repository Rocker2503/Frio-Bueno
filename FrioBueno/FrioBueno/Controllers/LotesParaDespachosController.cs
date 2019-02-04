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
    public class LotesParaDespachosController : Controller
    {
        private readonly FrioBuenoContext _context;

        public LotesParaDespachosController(FrioBuenoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Carga.ToListAsync());
        }

        //GET: LotesParaDespachos/AddCarga/5
        public async Task<IActionResult> AddCarga(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var carga = await _context.Carga.SingleOrDefaultAsync(m => m.Id == id);

            if(carga == null)
            {
                return NotFound();
            }
            return View(carga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCarga (int id, [Bind("Id,Producto,TipoProducto,UnidadSoportante,CantidadUS,Envase,KgNeto,IdCliente")] Carga carga)
        {
            if(id != carga.Id)
            {
                return NotFound();
            }

            var crg = _context.LotesParaDespacho.SingleOrDefault(m => m.IdCarga == id);
            if(crg == null)
            {
                if(ModelState.IsValid)
                {
                    try
                    {
                        _context.Database.ExecuteSqlCommand("Insert into LotesParaDespacho Values (@Nombre, @TipoProducto, @Envase, @IdCarga)",
                            new SqlParameter("Nombre", carga.Producto),
                            new SqlParameter("TipoProducto", carga.TipoProducto),
                            new SqlParameter("Envase", carga.Envase),
                            new SqlParameter("IdCarga", carga.Id)
                            );
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if(!CargaExists(carga.Id))
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
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CargaExists(int id)
        {
            return _context.LotesParaDespacho.Any(m => m.Id == id);
        }
    }
}