using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FrioBueno.Models
{
    public class Carga
    {
        [Display(Name = "N° Lote")]
        public int Id { get; set; } //Numero de Lote 
        public string Producto { get; set; }
        [Display(Name = "Tipo Producto")]
        public string TipoProducto { get; set; }
        public string UnidadSoportante { get; set; }
        public int CantidadUS { get; set; }
        public string Envase { get; set; }
        [Display(Name = "Kg Neto")]
        public string KgNeto { get; set; }

        [Display(Name = "Codigo Cliente")]
        public int IdCliente { get; set; }

        public Carga(int NumLote, string producto, string tipoProducto, string unidadSoporte, int cantidadUS, 
            string envase, string kgNeto)
        {
            this.Id = NumLote;
            this.Producto = producto;
            this.TipoProducto = tipoProducto;
            this.UnidadSoportante = unidadSoporte;
            this.CantidadUS = cantidadUS;
            this.Envase = envase;
            this.KgNeto = kgNeto;
        }

        public Carga()
        {

        }

        public static implicit operator TempDataAttribute(Carga v)
        {
            throw new NotImplementedException();
        }
    }
}
