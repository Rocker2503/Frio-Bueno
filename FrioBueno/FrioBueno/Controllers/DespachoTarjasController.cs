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

            return RedirectToAction("Index", "ProductosParaDespachos");
        }

        public async Task<IActionResult> PackOff()
        {
            string TipoDespacho = "Despacho Tarjas"; //Despacho por producto
            var productos = _context.ProductosParaDespacho.ToList();

            int numOrden;
            int NumGuia, FolioInterno, FolioExterno, CantidadEnvases;
            string Producto;

            var ultimo = _context.AsocDespachoProductos.LastOrDefault();
            //Solo para el primer Caso
            if (ultimo == null)
            {
                var UltimoDespacho = _context.Despacho.LastOrDefault();
                if(UltimoDespacho == null)
                {
                    numOrden = 1;
                }
                else
                {
                    numOrden = Convert.ToInt32(UltimoDespacho.NumOrden) + 1; 
                }
                foreach( var producto in productos)
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

        public bool ProductExists(int id)
        {
            return _context.ProductosParaDespacho.Any(m => m.Id == id);
        }
    }
}