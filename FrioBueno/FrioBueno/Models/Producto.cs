using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int NumGuia { get; set; }
        public int FolioExterno { get; set; }
        public int FolioInterno { get; set; }
        public string Nombre { get; set; }
        public string Envase { get; set; }
        public int Banda { get; set; }
        public int Piso { get; set; }
        public int Altura { get; set; }

        public Producto(int id, int numGuia, int folioExterno, int folioInterno, string nombre, string envase, int banda,
            int piso, int altura)
        {
            this.Id = id;
            this.NumGuia = numGuia;
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
