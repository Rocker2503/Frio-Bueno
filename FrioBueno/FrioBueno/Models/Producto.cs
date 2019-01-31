using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrioBueno.Models
{
    public class Producto 
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

        public Producto(int id, int numGuia, int folioExterno, int folioInterno, string nombre, string envase)
        {
            this.Id = id;
            this.NumGuia = numGuia;
            this.FolioExterno = folioExterno;
            this.FolioInterno = folioInterno;
            this.Nombre = nombre;
            this.Envase = envase;
        }

        public Producto()
        {

        }
        
    }
}
