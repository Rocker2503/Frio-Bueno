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

        [Display(Name = "N° Guia")]
        public int NumGuia { get; set; }

        [Display(Name = "Folio Interno")]
        public int FolioInterno { get; set; }

        [Display(Name = "Folio Externo")]
        public int FolioExterno { get; set; }

        [Display(Name = "N° Orden")]
        public int NumOrden { get; set; }

        public string Cliente { get; set; }

        [Display(Name = "Tipo Despacho")]
        public string TipoDespacho { get; set; }

        public string Producto { get; set; }

        [Display(Name = "Cantidad Envases")]
        public int CantidadEnvases { get; set; }

        public Despacho(int id, int numGuia, int folioInterno, int folioExterno, int numOrden, string cliente, string tipoDespacho, string producto, int cantidadEnvases)
        {
            Id = id;
            NumGuia = numGuia;
            FolioInterno = folioInterno;
            FolioExterno = folioExterno;
            NumOrden = numOrden;
            Cliente = cliente;
            TipoDespacho = tipoDespacho;
            Producto = producto;
            CantidadEnvases = cantidadEnvases;
        }

        public Despacho()
        {

        }
    }
}
