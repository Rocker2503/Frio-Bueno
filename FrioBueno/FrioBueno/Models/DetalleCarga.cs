using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FrioBueno.Models
{
    public class DetalleCarga
    {
        [Display(Name = "Folio Interno")]
        public int Id { get; set; } //Folio Interno

        [Display(Name = "N° Lote")]
        public int IdCarga { get; set; } //Numero de Lote

        public string Producto { get; set; }
        public string Envase { get; set; }

        [Display(Name = "Cantidad Envases")]
        public int CantidadEnvases { get; set; }

        [Display(Name = "Kg Envase")]
        public string KgEnvase { get; set; }

        [Display(Name = "Folio Externo")]
        public int FolioExterno { get; set; }

        public DetalleCarga(int folioInterno, int idCarga, string producto, string envase, int cantidadEnvases, string kgEnvase,
            int folioExterno)
        {
            this.Id = folioInterno;
            this.IdCarga = idCarga;
            this.Producto = producto;
            this.Envase = envase;
            this.CantidadEnvases = cantidadEnvases;
            this.KgEnvase = kgEnvase;
            this.FolioExterno = folioExterno;
        }

        public DetalleCarga()
        {

        }
    }
}
