using Rafael.LocalizaAmigos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafael.AcessoDados.Entity.TypeConfig
{
    public class AmigoTypeConfig : EntityConfig<Amigo>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasColumnName("AMI_ID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("AMI_NOME")
                .HasMaxLength(255);

            Property(p => p.SobreNome)
                .IsRequired()
                .HasColumnName("AMI_SOBRE")
                .HasMaxLength(255);

            Property(p => p.Latitude)
                .IsRequired()
                .HasColumnName("AMI_LATITUDE");

            Property(p => p.Longitude)
                .IsRequired()
                .HasColumnName("AMI_LONGITUDE");

        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            //HasRequired(p => p.Musica)
            //    .WithMany(p => p.Album)
            //    .HasForeignKey(fk => fk.)
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("LOCALIZA_AMIGOS");
        }
    }
}
