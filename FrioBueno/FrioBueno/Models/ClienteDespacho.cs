using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrioBueno.Models
{
    public class ClienteDespacho
    {
        [Display (Name ="N° de Guia")]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Patente { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaDespacho { get; set; }

        public int Temperatura { get; set; }

        [Display (Name = "N° Sello")]
        public int NumSello { get; set; }

        [Display (Name = "N° Orden")]
        public int IdOrden { get; set; }

        public ClienteDespacho( int id, string nombre, string patente, DateTime fechaDespacho, int temperatura, int numSello, int idOrden)
        {
            Id = id;
            Nombre = nombre;
            Patente = patente;
            FechaDespacho = fechaDespacho;
            Temperatura = temperatura;
            NumSello = numSello;
            IdOrden = idOrden;
        }

        public ClienteDespacho()
        {

        }
    }
}
