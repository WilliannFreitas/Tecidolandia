namespace Tecidolandia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VENDA_ITEM", "ValorTotalVenda", c => c.Double());
            AddColumn("dbo.VENDA_ITEM", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VENDA_ITEM", "Discriminator");
            DropColumn("dbo.VENDA_ITEM", "ValorTotalVenda");
        }
    }
}
