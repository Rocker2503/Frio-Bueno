using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrioBueno.Models
{
    public class Cliente
    {
        
        public int Id { get; set; }
        [Display(Name = "Cliente")]
        public string Nombre { get; set; }
        [Display(Name = "N° de Guia")]
        public int NumGuia { get; set; }
        public string Patente { get; set; }
        [Display(Name = "Transportista")]
        public string Transporte { get; set; }
        public string Conductor { get; set; }
        [Display(Name = "Rut del Conductor")]
        public string RutConductor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public int Temperatura { get; set; }
        
        [Display(Name = "N° Sello")]
        public int NumSello { get; set; }

        [Display(Name = "Peso Guia")]
        public string PesoGuia { get; set; }

        public Cliente(int id, string nombre, int numGuia, string patente, string transporte, string conductor, string rutConductor,
            DateTime fecha, int temperatura,int numSello, string pesoGuia)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.NumGuia = numGuia;
            this.Patente = patente;
            this.Transporte = transporte;
            this.Conductor = conductor;
            this.RutConductor = rutConductor;
            this.Fecha = fecha;
            this.Temperatura = temperatura;
            this.NumSello = numSello;
            this.PesoGuia = pesoGuia;           
        }

        public Cliente()
        {

        }
    }   
}
