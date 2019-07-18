using Rafael.AcessoDados.Entity.TypeConfig;
using Rafael.LocalizaAmigos.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafael.AcessoDados.Entity.Context
{
    public class AcessoDadosDbContext : DbContext
    {
        public DbSet<Amigo> Amigos { get; set; }

        public AcessoDadosDbContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AmigoTypeConfig());
        }
    }
}
