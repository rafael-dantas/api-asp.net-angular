namespace Rafael.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBancoLocalizaAmigo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LOCALIZA_AMIGOS", "AMI_LATITUDE", c => c.Double(nullable: false));
            AlterColumn("dbo.LOCALIZA_AMIGOS", "AMI_LONGITUDE", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LOCALIZA_AMIGOS", "AMI_LONGITUDE", c => c.Long(nullable: false));
            AlterColumn("dbo.LOCALIZA_AMIGOS", "AMI_LATITUDE", c => c.Long());
        }
    }
}
