using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class OrdenDespacho
    {
        private int Id { get; set; }
        private int CantidadProductos { get; set; }

        public OrdenDespacho(int id, int cantidadProductos)
        {
            this.Id = id;
            this.CantidadProductos = cantidadProductos;
        }

        public OrdenDespacho()
        {

        }
    }
}
