namespace Rafael.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtuaiarBanco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOCALIZA_AMIGOS", "Distancia", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LOCALIZA_AMIGOS", "Distancia");
        }
    }
}
