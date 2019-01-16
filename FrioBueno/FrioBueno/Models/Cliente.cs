using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class Cliente
    {
        private int Id { get; set; }
        private string Nombre { get; set; }
        private int NumeroGuia { get; set; }
        private string Fecha { get; set; }
        private string Conductor { get; set; }
        private string RutConductor { get; set; }
        private string Transporte { get; set; }
        private int PesoGuia { get; set; }

        public Cliente(int id, string nombre, int numGuia, string fecha, string conductor, string rutConductor, 
            string transporte, int pesoGuia)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.NumeroGuia = numGuia;
            this.Fecha = fecha;
            this.Conductor = conductor;
            this.RutConductor = rutConductor;
            this.Transporte = transporte;
            this.PesoGuia = pesoGuia;
        }

        public Cliente()
        {

        }
    }   
}
