using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrioBueno.Models
{
    public class Despacho
    {
        public int Id { get; set; }
        public int IdOrdenDespacho { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int NumeroGuia { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public Despacho(int id, int idOrdenDespacho, int idCliente, string nombre, int numGuia, DateTime fecha)
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
