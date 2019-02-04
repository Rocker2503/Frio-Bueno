using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class LotesParaDespacho
    {
        public int Id { get; set; }
        [Display(Name = "Producto")]
        public string Nombre { get; set; }
        [Display(Name = "Tipo de Producto")]
        public string TipoProducto { get; set; }
        public string Envase { get; set; }
        [Display(Name = "N° Lote")]
        public int IdCarga { get; set; }

        public LotesParaDespacho(int id, string nombre, string tipoProducto, string envase, int idCarga)
        {
            Id = id;
            Nombre = nombre;
            TipoProducto = tipoProducto;
            Envase = envase;
            IdCarga = idCarga;
        }

        public LotesParaDespacho()
        {

        }
    }
}
