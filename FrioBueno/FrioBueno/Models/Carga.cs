using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class Carga
    {
        private int NumeroLote { get; set; }
        private string Producto { get; set; }
        private string TipoProducto { get; set; }
        private string UnidadSoportante { get; set; }
        private int CantidadUS { get; set; }
        private string Envase { get; set; }
        private int KgNeto { get; set; }
        private int IdCliente { get; set; }

        public Carga(int numeroLote, string producto, string tipoProducto, string unidadSoporte, int cantidadUS, 
            string envase, int kgNeto, int idCliente)
        {
            this.NumeroLote = numeroLote;
            this.Producto = producto;
            this.TipoProducto = tipoProducto;
            this.UnidadSoportante = unidadSoporte;
            this.CantidadUS = cantidadUS;
            this.Envase = envase;
            this.KgNeto = kgNeto;
            this.IdCliente = idCliente;
        }

        public Carga()
        {

        }
    }
}
