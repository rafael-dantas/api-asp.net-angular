using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafael.LocalizaAmigos.Dominio
{
    public class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distancia { get; set; }
    }
}
