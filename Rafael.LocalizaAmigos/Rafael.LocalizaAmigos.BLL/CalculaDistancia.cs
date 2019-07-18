using Rafael.AcessoDados.Entity.Context;
using Rafael.LocalizaAmigos.Dominio;
using Rafael.LocalizaAmigos.Repositorio.Entity;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafael.LocalizaAmigos.BLL
{
    public class CalculaDistancia
    {        

        public static List<Amigo> ListaAmigosProximo(int id)
        {
            RepositorioAmigos _repositorio = new RepositorioAmigos(new AcessoDadosDbContext());

            List<Amigo> LA = new List<Amigo>();
            List<Amigo> lista = _repositorio.Selecionar();
            Amigo amigo = _repositorio.SelecionarPorId(id);
            Dictionary<double,Amigo> dc = new Dictionary<double, Amigo>();
            foreach (Amigo a in lista)
            {
                if (!(a.Id == amigo.Id))
                {
                    double distancia = CalcularDistancia(amigo.Latitude, amigo.Longitude, a.Latitude, a.Longitude);
                    a.Distancia = distancia;
                    dc.Add(distancia,a);
                }
            }

            var dic = dc.Keys.ToList();
            dic.Sort();

            int cont = 1;
            foreach (double a in dic)
            {
                if (cont < 4)
                {
                    LA.Add(dc[a]);
                    cont++;
                }
                else
                {
                    break;
                }
            }

            return LA;

        }


        private static double CalcularDistancia(double origem_lat, double origem_lng, double destino_lat, double destino_lng)
        {
            double x1 = origem_lat;
            double x2 = destino_lat;
            double y1 = origem_lng;
            double y2 = destino_lng;

            var localOrig = new GeoCoordinate(x1, y1);
            var localDest = new GeoCoordinate(x2, y2);

            double distancia = (localOrig.GetDistanceTo(localDest) / 1000);           

            return distancia;
        }
    }
}
