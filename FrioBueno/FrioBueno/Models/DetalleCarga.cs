using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class DetalleCarga
    {
        public int Id { get; set; } //Folio Interno
        public int IdCarga { get; set; } //Numero de Lote
        public string Producto { get; set; }
        public string Envase { get; set; }
        public int KgEnvase { get; set; }
        public int FolioExterno { get; set; }

        public DetalleCarga(int folioInterno, string producto, string envase, int kgEnvase,
            int folioExterno)
        {
            this.Id = folioInterno;
            this.Producto = producto;
            this.Envase = envase;
            this.KgEnvase = kgEnvase;
            this.FolioExterno = folioExterno;
        }

        public DetalleCarga()
        {

        }
    }
}
