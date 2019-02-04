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
    public class ProductosParaDespachosController : Controller
    {
        private readonly FrioBuenoContext _context;

        public ProductosParaDespachosController(FrioBuenoContext context)
        {
            _context = context;
        }

        // GET: ProductosParaDespachos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producto.ToListAsync());
        }

        // GET: ProductosParaDespachos/AddProducto/5
        public async Task<IActionResult> AddProducto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.SingleOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: ProductosParaDespachos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProducto(int id, [Bind("Id,NumGuia,FolioExterno,FolioInterno,Nombre,Envase,CantidadEnvases")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            var prd = _context.ProductosParaDespacho.SingleOrDefault(m => m.IdProducto == id);

            if (prd == null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Database.ExecuteSqlCommand("Insert into ProductosParaDespacho Values(@NumGuia, @FolioExterno, @FolioInterno, @Nombre, @Envase, @CantidadEnvases, @IdProducto)",
                            new SqlParameter("NumGuia", producto.NumGuia),
                            new SqlParameter("FolioExterno", producto.FolioExterno),
                            new SqlParameter("FolioInterno", producto.FolioInterno),
                            new SqlParameter("Nombre", producto.Nombre),
                            new SqlParameter("Envase", producto.Envase),
                            new SqlParameter("CantidadEnvases", producto.CantidadEnvases),
                            new SqlParameter("IdProducto", producto.Id)
                        );
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductoExists(producto.Id))
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

        private bool ProductoExists(int id)
        {
            return _context.ProductosParaDespacho.Any(e => e.Id == id);
        }
    }
}
