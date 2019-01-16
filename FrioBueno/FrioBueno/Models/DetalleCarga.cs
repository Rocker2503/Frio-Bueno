using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class DetalleCarga
    {
        private int FolioInterno { get; set; }
        private int NumeroLote { get; set; }
        private string Producto { get; set; }
        private string Envase { get; set; }
        private int KgEnvase { get; set; }
        private int FolioExterno { get; set; }

        public DetalleCarga(int folioInterno, int numeroLote, string producto, string envase, int kgEnvase,
            int folioExterno)
        {
            this.FolioInterno = folioInterno;
            this.NumeroLote = numeroLote;
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
