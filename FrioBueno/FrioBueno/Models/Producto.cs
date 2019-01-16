using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class Producto
    {
        private int Id { get; set; }
        private int NumeroGuia { get; set; }
        private int FolioExterno { get; set; }
        private int FolioInterno { get; set; }
        private string Nombre { get; set; }
        private string Envase { get; set; }
        private int Banda { get; set; }
        private int Piso { get; set; }
        private int Altura { get; set; }

        public Producto(int id, int numGuia, int folioExterno, int folioInterno, string nombre, string envase, int banda,
            int piso, int altura)
        {
            this.Id = id;
            this.NumeroGuia = numGuia;
            this.FolioExterno = folioExterno;
            this.FolioInterno = folioInterno;
            this.Nombre = nombre;
            this.Envase = envase;
            this.Banda = banda;
            this.Piso = piso;
            this.Altura = altura;
        }

        public Producto()
        {

        }
        
    }
}
