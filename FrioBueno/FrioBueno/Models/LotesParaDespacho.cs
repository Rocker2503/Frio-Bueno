using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrioBueno.Models
{
    public class LotesParaDespacho
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; }
        public string Envase { get; set; }
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
