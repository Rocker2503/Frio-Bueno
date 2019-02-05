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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = await _context.ProductosParaDespacho.SingleOrDefaultAsync(m => m.Id == id);
            if (producto == null)
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

            return RedirectToAction(nameof(ShowProducts));
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nombre, Patente, FechaDespacho, Temperatura, NumSello, IdOrden")] ClienteDespacho cliente)
        {
            var orden = _context.AsocDespachoProductos.LastOrDefault();
            cliente.IdOrden = orden.NumOrden;

            if (ModelState.IsValid)
            {
                _context.ClienteDespachos.Add(cliente);
                await _context.SaveChangesAsync();

                var despachos = from AsocDespachoProductos in _context.AsocDespachoProductos
                                join ClienteDespacho in _context.ClienteDespachos on AsocDespachoProductos.NumOrden equals ClienteDespacho.IdOrden
                                select new
                                {
                                    NumGuia = AsocDespachoProductos.NumGuia,
                                    FolioInterno = AsocDespachoProductos.FolioInterno,
                                    FolioExterno = AsocDespachoProductos.FolioExterno,
                                    NumOrden = AsocDespachoProductos.NumOrden,
                                    Cliente = ClienteDespacho.Nombre,
                                    TipoDespacho = AsocDespachoProductos.TipoDespacho,
                                    Producto = AsocDespachoProductos.Producto,
                                    CantidadEnvases = AsocDespachoProductos.CantidadEnvases
                                };


                foreach (var despacho in despachos.ToList())
                {
                    int NumGuia = Convert.ToInt32(despacho.NumGuia);
                    int FolioInterno = Convert.ToInt32(despacho.FolioInterno);
                    int FolioExterno = Convert.ToInt32(despacho.FolioExterno);
                    int NumOrden = Convert.ToInt32(despacho.NumOrden);
                    string Cliente = Convert.ToString(despacho.Cliente);
                    string TipoDespacho = Convert.ToString(despacho.TipoDespacho);
                    string Producto = Convert.ToString(despacho.Producto);
                    int CantidadEnvases = Convert.ToInt32(despacho.CantidadEnvases);

                    var prod = _context.Producto.FirstOrDefault(m => m.FolioInterno == FolioInterno);
                    var detalle = _context.DetalleCarga.FirstOrDefault(m => m.Id == FolioInterno);
                    int idCarga = Convert.ToInt32(detalle.IdCarga);

                    int resto = Convert.ToInt32(prod.CantidadEnvases) - CantidadEnvases;

                    if (resto > 0)
                    {
                        prod.CantidadEnvases = resto;
                        detalle.CantidadEnvases = resto;

                        _context.Producto.Update(prod);
                        _context.DetalleCarga.Update(detalle);

                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Producto.Remove(prod);
                        _context.DetalleCarga.Remove(detalle);

                        await _context.SaveChangesAsync();

                        var detalles = _context.DetalleCarga.Where(m => m.IdCarga == idCarga).ToList();
                        var carga = _context.Carga.FirstOrDefault(m => m.Id == idCarga);
                        if(detalles.Count() == 0)
                        {
                            _context.Carga.Remove(carga);
                            await _context.SaveChangesAsync();
                        }
                    }

                    _context.Database.ExecuteSqlCommand("INSERT INTO Despacho VALUES (@NumGuia, @FolioInterno, @FolioExterno, @NumOrden, @Cliente," +
                        "@TipoDespacho, @Producto, @CantidadEnvases)",
                        new SqlParameter("NumGuia", NumGuia),
                        new SqlParameter("FolioInterno", FolioInterno),
                        new SqlParameter("FolioExterno", FolioExterno),
                        new SqlParameter("NumOrden", NumOrden),
                        new SqlParameter("Cliente", Cliente),
                        new SqlParameter("TipoDespacho", TipoDespacho),
                        new SqlParameter("Producto", Producto),
                        new SqlParameter("CantidadEnvases", CantidadEnvases)
                        );

                    _context.Database.ExecuteSqlCommand("Delete from ProductosParaDespacho Where FolioInterno = @FolioInterno",
                        new SqlParameter("FolioInterno", FolioInterno)
                        );
                }
 
                var productos = _context.AsocDespachoProductos.ToList();
                _context.AsocDespachoProductos.RemoveRange(productos);
                await _context.SaveChangesAsync();

                var clientes = _context.ClienteDespachos.ToList();
                _context.ClienteDespachos.RemoveRange(clientes);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.Id == id);
        }
    }
}