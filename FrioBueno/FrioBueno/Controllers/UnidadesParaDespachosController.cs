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
    public class UnidadesParaDespachosController : Controller
    {
        private readonly FrioBuenoContext _context;

        public UnidadesParaDespachosController(FrioBuenoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Producto.ToListAsync());
        }

        public async Task<IActionResult> ShowProducts()
        {
            return View(await _context.ProductosParaDespacho.ToListAsync());
        }

        public async Task<IActionResult> AddUnits(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUnits(int id, [Bind("Id,NumGuia,FolioExterno,FolioInterno,Nombre,Envase,CantidadEnvases")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            var prd = _context.ProductosParaDespacho.SingleOrDefault(m => m.IdProducto == id);

            if (prd == null)
            {
                var prod = _context.Producto.SingleOrDefault(m => m.Id == id);
                int CantidadEnvases = Convert.ToInt32(prod.CantidadEnvases);

                if (producto.CantidadEnvases > CantidadEnvases || producto.CantidadEnvases <= 0)
                {
                    return RedirectToAction(nameof(Index));
                }

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

        public async Task<IActionResult> PackOff()
        {
            string TipoDespacho = "Despacho Unidades"; //Despacho por producto
            var productos = _context.ProductosParaDespacho.ToList();

            int numOrden;
            int NumGuia, FolioInterno, FolioExterno, CantidadEnvases;
            string Producto;

            var ultimo = _context.AsocDespachoProductos.LastOrDefault();
            //Solo para el primer Caso
            if (ultimo == null)
            {
                var UltimoDespacho = _context.Despacho.LastOrDefault();
                if (UltimoDespacho == null)
                {
                    numOrden = 1;
                }
                else
                {
                    numOrden = Convert.ToInt32(UltimoDespacho.NumOrden) + 1;
                }
                foreach (var producto in productos)
                {
                    NumGuia = Convert.ToInt32(producto.NumGuia);
                    FolioInterno = Convert.ToInt32(producto.FolioInterno);
                    FolioExterno = Convert.ToInt32(producto.FolioExterno);
                    Producto = Convert.ToString(producto.Nombre);
                    CantidadEnvases = Convert.ToInt32(producto.CantidadEnvases);

                    _context.Database.ExecuteSqlCommand("INSERT INTO AsocDespachoProductos VALUES(@NumOrden, @TipoDespacho, @NumGuia, @FolioInterno, @FolioExterno, @Producto, @CantidadEnvases)",
                        new SqlParameter("NumOrden", numOrden),
                        new SqlParameter("TipoDespacho", TipoDespacho),
                        new SqlParameter("NumGuia", NumGuia),
                        new SqlParameter("FolioInterno", FolioInterno),
                        new SqlParameter("FolioExterno", FolioExterno),
                        new SqlParameter("Producto", Producto),
                        new SqlParameter("CantidadEnvases", CantidadEnvases)
                        );

                    await _context.SaveChangesAsync();
                }

            }
            else //Hay elementos en la tabla
            {
                numOrden = Convert.ToInt32(ultimo.NumOrden);
                _context.Database.ExecuteSqlCommand("DELETE FROM AsocDespachoProductos WHERE NumOrden = @numOrden",
                    new SqlParameter("@numOrden", numOrden)
                    );

                await _context.SaveChangesAsync();

                foreach (var producto in productos)
                {
                    NumGuia = Convert.ToInt32(producto.NumGuia);
                    FolioInterno = Convert.ToInt32(producto.FolioInterno);
                    FolioExterno = Convert.ToInt32(producto.FolioExterno);
                    Producto = Convert.ToString(producto.Nombre);
                    CantidadEnvases = Convert.ToInt32(producto.CantidadEnvases);

                    _context.Database.ExecuteSqlCommand("INSERT INTO AsocDespachoProductos VALUES(@NumOrden, @TipoDespacho, @NumGuia, @FolioInterno, @FolioExterno, @Producto, @CantidadEnvases)",
                        new SqlParameter("NumOrden", numOrden),
                        new SqlParameter("TipoDespacho", TipoDespacho),
                        new SqlParameter("NumGuia", NumGuia),
                        new SqlParameter("FolioInterno", FolioInterno),
                        new SqlParameter("FolioExterno", FolioExterno),
                        new SqlParameter("Producto", Producto),
                        new SqlParameter("CantidadEnvases", CantidadEnvases)
                        );

                    await _context.SaveChangesAsync();
                }
            }
            return View(await _context.AsocDespachoProductos.Where(m => m.NumOrden == numOrden).ToListAsync());
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.Id == id);
        }
    }
}