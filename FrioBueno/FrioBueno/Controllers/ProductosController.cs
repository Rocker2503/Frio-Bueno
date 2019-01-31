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
    public class ProductosController : Controller
    {
        private readonly FrioBuenoContext _context;

        public ProductosController(FrioBuenoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            FillProductosTable();

            return View(await _context.Producto.ToListAsync());
        }

        private void FillProductosTable()
        {
            var producto = from Cliente in _context.Cliente
                           join Carga in _context.Carga on Cliente.Id equals Carga.IdCliente
                           join DetalleCarga in _context.DetalleCarga on Carga.Id equals DetalleCarga.IdCarga
                           select new
                           {
                               NumGuia = Cliente.NumGuia,
                               FolioExterno = DetalleCarga.FolioExterno,
                               FolioInterno = DetalleCarga.Id,
                               Nombre = DetalleCarga.Producto,
                               Envase = DetalleCarga.Envase,
                               CantidadEnvases = DetalleCarga.CantidadEnvases
                           };

            int NumGuia;
            int FolioExterno;
            int FolioInterno;
            string Nombre;
            string Envase;
            int CantidadEnvases;

            foreach (var prod in producto)
            {
                var numGuia = prod.NumGuia;
                var folioExterno = prod.FolioExterno;
                var folioInterno = prod.FolioInterno;
                var nombre = prod.Nombre;
                var envase = prod.Envase;
                var cantidadEnvases = prod.CantidadEnvases;

                NumGuia = Convert.ToInt32(numGuia);
                FolioExterno = Convert.ToInt32(folioExterno);
                FolioInterno = Convert.ToInt32(folioInterno);
                Nombre = Convert.ToString(nombre);
                Envase = Convert.ToString(envase);
                CantidadEnvases = Convert.ToInt32(cantidadEnvases);

                var pr = _context.Producto.Where(p => p.NumGuia == NumGuia && p.FolioExterno == FolioExterno &&
                    p.FolioInterno == FolioInterno).FirstOrDefault();

                if (pr == null)
                {
                    _context.Database.ExecuteSqlCommand("Insert into Producto Values(@NumGuia, @FolioExterno, @FolioInterno, @Nombre, @Envase, @CantidadEnvases)",
                    new SqlParameter("NumGuia", NumGuia),
                    new SqlParameter("FolioExterno", FolioExterno),
                    new SqlParameter("FolioInterno", FolioInterno),
                    new SqlParameter("Nombre", Nombre),
                    new SqlParameter("Envase", Envase),
                    new SqlParameter("CantidadEnvases", CantidadEnvases)
                    );

                    _context.SaveChanges();
                }
                else
                {
                    continue;
                }
            }

        }
    }
}
