using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafael.LocalizaAmigos.Api.DTOs
{
    public class AmigoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public double Distancia { get; set; }
    }
}