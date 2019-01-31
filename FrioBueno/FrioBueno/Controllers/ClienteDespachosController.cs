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
            return View(await _context.ClienteDespachos.ToListAsync());
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

            if(ModelState.IsValid)
            {
                _context.ClienteDespachos.Add(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}