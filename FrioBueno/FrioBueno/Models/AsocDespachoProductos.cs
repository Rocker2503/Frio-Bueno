using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class AsocDespachoProductos
    {   
        public int Id { get; set; }

        [Display(Name = "N° Despacho")]
        public int NumOrden { get; set; }

        [Display(Name = "Tipo de Despacho")]
        public string TipoDespacho { get; set; }

        [Display(Name = "N° Guia")]
        public int NumGuia { get; set; }

        [Display(Name = "Folio Interno")]
        public int FolioInterno { get; set; }

        [Display(Name = "Folio Externo")]
        public int FolioExterno { get; set; }

        [Display(Name = "Producto")]
        public string Producto { get; set; }

        public AsocDespachoProductos(int id, int numOrden, string tipoDespacho, int numGuia, int folioInterno, int folioExterno, string producto)
        {
            Id = id;
            NumOrden = numOrden;
            TipoDespacho = tipoDespacho;
            NumGuia = numGuia;
            FolioInterno = folioInterno;
            FolioExterno = folioExterno;
            Producto = producto;
        }

        public AsocDespachoProductos()
        {

        }
    }
}
