using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class OrdenDespacho
    {
        public int Id { get; set; }
        public int CantidadProductos { get; set; }

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
