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

        public async Task<IActionResult> PackOff()
        {
            string TipoDespacho = "Despacho por Lote";

            int numOrden;
            int NumGuia, FolioInterno, FolioExterno;
            string NombreProducto;

            var ultimo = _context.AsocDespachoProductos.LastOrDefault();
            if(ultimo == null)
            {
                numOrden = 1;
                var productos = from LotesParaDespacho in _context.LotesParaDespacho
                              join DetalleCarga in _context.DetalleCarga on LotesParaDespacho.IdCarga equals DetalleCarga.IdCarga
                              join Producto in _context.Producto on DetalleCarga.Id equals Producto.FolioInterno
                              select new
                              {
                                  NumGuia = Producto.NumGuia,
                                  FolioInterno = DetalleCarga.Id,
                                  FolioExterno = DetalleCarga.FolioExterno,
                                  Nombre = DetalleCarga.Producto
                                };
                
                foreach(var prod in productos)
                {
                    NumGuia = Convert.ToInt32(prod.NumGuia);
                    FolioInterno = Convert.ToInt32(prod.FolioInterno);
                    FolioExterno = Convert.ToInt32(prod.FolioExterno);
                    NombreProducto = Convert.ToString(prod.Nombre);

                    _context.Database.ExecuteSqlCommand("INSERT INTO AsocDespachoProductos VALUES(@NumOrden, @TipoDespacho, @NumGuia, @FolioInterno, @FolioExterno, @Producto)",
                            new SqlParameter("NumOrden", numOrden),
                            new SqlParameter("TipoDespacho", TipoDespacho),
                            new SqlParameter("NumGuia", NumGuia),
                            new SqlParameter("FolioInterno", FolioInterno),
                            new SqlParameter("FolioExterno", FolioExterno),
                            new SqlParameter("Producto", NombreProducto)
                    );

                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                numOrden = Convert.ToInt32(ultimo.NumOrden) + 1;
                var productos = from LotesParaDespacho in _context.LotesParaDespacho
                                join DetalleCarga in _context.DetalleCarga on LotesParaDespacho.IdCarga equals DetalleCarga.IdCarga
                                join Producto in _context.Producto on DetalleCarga.Id equals Producto.FolioInterno
                                select new
                                {
                                    NumGuia = Producto.NumGuia,
                                    FolioInterno = DetalleCarga.Id,
                                    FolioExterno = DetalleCarga.FolioExterno,
                                    Nombre = DetalleCarga.Producto
                                };

                foreach (var prod in productos)
                {
                    NumGuia = Convert.ToInt32(prod.NumGuia);
                    FolioInterno = Convert.ToInt32(prod.FolioInterno);
                    FolioExterno = Convert.ToInt32(prod.FolioExterno);
                    NombreProducto = Convert.ToString(prod.Nombre);

                    _context.Database.ExecuteSqlCommand("INSERT INTO AsocDespachoProductos VALUES(@NumOrden, @TipoDespacho, @NumGuia, @FolioInterno, @FolioExterno, @Producto)",
                            new SqlParameter("NumOrden", numOrden),
                            new SqlParameter("TipoDespacho", TipoDespacho),
                            new SqlParameter("NumGuia", NumGuia),
                            new SqlParameter("FolioInterno", FolioInterno),
                            new SqlParameter("FolioExterno", FolioExterno),
                            new SqlParameter("Producto", NombreProducto)
                    );

                    await _context.SaveChangesAsync();
                }
            }

            return View(await _context.AsocDespachoProductos.Where(m => m.NumOrden == numOrden).ToListAsync());
        }
    }
}