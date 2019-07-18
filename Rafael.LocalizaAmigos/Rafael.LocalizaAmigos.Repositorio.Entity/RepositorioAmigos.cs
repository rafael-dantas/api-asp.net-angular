using Rafael.AcessoDados.Entity;
using Rafael.AcessoDados.Entity.Context;
using Rafael.LocalizaAmigos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafael.LocalizaAmigos.Repositorio.Entity
{
    public class RepositorioAmigos : AcessoDadosEntity<Amigo,int>
    {
        public RepositorioAmigos(AcessoDadosDbContext context)
            : base(context)
        {

        }
    }
}
