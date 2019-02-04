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
    public class ClienteDespachosController : Controller
    {
        private readonly FrioBuenoContext _context;

        public ClienteDespachosController(FrioBuenoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Despacho.ToListAsync());
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
            bool isDespachoLotes = false;
            bool isDespachoUnidades = false;

            if (orden.TipoDespacho.ToString().Equals("Despacho Lotes"))
            {
                isDespachoLotes = true;
            }
            if(orden.TipoDespacho.ToString().Equals("Despacho Unidades"))
            {
                isDespachoUnidades = true;
            }
            cliente.IdOrden = orden.NumOrden;

            if(ModelState.IsValid)
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


                foreach(var despacho in despachos)
                {
                    int NumGuia = Convert.ToInt32(despacho.NumGuia);
                    int FolioInterno = Convert.ToInt32(despacho.FolioInterno);
                    int FolioExterno = Convert.ToInt32(despacho.FolioExterno);
                    int NumOrden = Convert.ToInt32(despacho.NumOrden);
                    string Cliente = Convert.ToString(despacho.Cliente);
                    string TipoDespacho = Convert.ToString(despacho.TipoDespacho);
                    string Producto = Convert.ToString(despacho.Producto);
                    int CantidadEnvases = Convert.ToInt32(despacho.CantidadEnvases);

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


                        _context.Database.ExecuteSqlCommand("Delete from Producto Where FolioInterno = @FolioInterno",
                            new SqlParameter("FolioInterno", FolioInterno)
                            );

                        _context.Database.ExecuteSqlCommand("Delete from DetalleCarga Where Id = @FolioInterno",
                            new SqlParameter("FolioInterno", FolioInterno)
                            );
                }

                await _context.SaveChangesAsync();
                

                if(isDespachoLotes)
                {
                    var lotes = _context.LotesParaDespacho.ToList();
                    foreach( var lote in lotes)
                    {
                        int idCarga = Convert.ToInt32(lote.IdCarga);

                        _context.LotesParaDespacho.Remove(lote);
                        await _context.SaveChangesAsync();

                        var carga = _context.Carga.SingleOrDefault(m => m.Id == idCarga);
                        _context.Carga.Remove(carga);

                        await _context.SaveChangesAsync();
                    }
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
    }
}