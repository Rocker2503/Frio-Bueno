using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrioBueno.Models
{
    public class ProductosParaDespacho
    {
        public int Id { get; set; }

        [Display(Name = "N° Guia")]
        public int NumGuia { get; set; }

        [Display(Name = "Folio Externo")]
        public int FolioExterno { get; set; }

        [Display(Name = "Folio Interno")]
        public int FolioInterno { get; set; }

        [Display(Name = "Producto")]
        public string Nombre { get; set; }

        public string Envase { get; set; }

        [Display(Name = "Cantidad Envases")]
        public int CantidadEnvases { get; set; }

        public int IdProducto { get; set; }

        public ProductosParaDespacho(int id, int numGuia, int folioExterno, int folioInterno, string nombre, string envase, int cantidadEnvases,
            int idProducto)
        {
            Id = id;
            NumGuia = numGuia;
            FolioExterno = FolioExterno;
            FolioInterno = FolioInterno;
            Nombre = nombre;
            Envase = envase;
            CantidadEnvases = cantidadEnvases;
            IdProducto = idProducto;
        }

        public ProductosParaDespacho()
        {

        }
    }
}
