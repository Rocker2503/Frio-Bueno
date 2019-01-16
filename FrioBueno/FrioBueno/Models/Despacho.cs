using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class Despacho
    {
        private int Id { get; set; }
        private int IdOrdenDespacho { get; set; }
        private int IdCliente { get; set; }
        private string Nombre { get; set; }
        private int NumeroGuia { get; set; }
        private string Fecha { get; set; }

        public Despacho(int id, int idOrdenDespacho, int idCliente, string nombre, int numGuia, string fecha)
        {
            this.Id = id;
            this.IdOrdenDespacho = idOrdenDespacho;
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.NumeroGuia = numGuia;
            this.Fecha = fecha;
        }

        public Despacho()
        {

        }

    }
}
