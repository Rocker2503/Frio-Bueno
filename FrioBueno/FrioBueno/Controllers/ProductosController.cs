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

        // GET: Productos
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
                               Envase = DetalleCarga.Envase
                           };

            int NumGuia;
            int FolioExterno;
            int FolioInterno;
            string Nombre;
            string Envase;

            foreach(var prod in producto)
            {
                var numGuia = prod.NumGuia;
                var folioExterno = prod.FolioExterno;
                var folioInterno = prod.FolioInterno;
                var nombre = prod.Nombre;
                var envase = prod.Envase;

                NumGuia = Convert.ToInt32(numGuia);
                FolioExterno = Convert.ToInt32(folioExterno);
                FolioInterno = Convert.ToInt32(folioInterno);
                Nombre = Convert.ToString(nombre);
                Envase = Convert.ToString(envase);

                var pr = _context.Producto.Where(p => p.NumGuia == NumGuia && p.FolioExterno == FolioExterno &&
                    p.FolioInterno == FolioInterno).FirstOrDefault();

                if(pr == null)
                {
                    _context.Database.ExecuteSqlCommand("Insert into Producto Values(@NumGuia, @FolioExterno, @FolioInterno, @Nombre, @Envase)",
                    new SqlParameter("NumGuia", NumGuia),
                    new SqlParameter("FolioExterno", FolioExterno),
                    new SqlParameter("FolioInterno", FolioInterno),
                    new SqlParameter("Nombre", Nombre),
                    new SqlParameter("Envase", Envase)
                    );

                    _context.SaveChanges();
                }
                else
                {
                    continue;
                }
            }
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .SingleOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumGuia,FolioExterno,FolioInterno,Nombre,Envase")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumGuia,FolioExterno,FolioInterno,Nombre,Envase")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
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
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .SingleOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.SingleOrDefaultAsync(m => m.Id == id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.Id == id);
        }
    }
}
