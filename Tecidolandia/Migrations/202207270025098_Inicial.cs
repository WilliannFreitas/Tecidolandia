namespace Tecidolandia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CLIENTE",
                c => new
                    {
                        ID_CLIENTE = c.Int(nullable: false, identity: true),
                        NM_COMPLETO = c.String(),
                        FACEBOOK = c.String(),
                        DT_REGISTRO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_CLIENTE);
            
            CreateTable(
                "dbo.PRODUTO",
                c => new
                    {
                        ID_PRODUTO = c.Long(nullable: false, identity: true),
                        NOME = c.String(),
                        DESCRICAO = c.String(),
                        ID_TIPO_ESTAMPA = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID_PRODUTO)
                .ForeignKey("dbo.TIPO_ESTAMPA", t => t.ID_TIPO_ESTAMPA)
                .Index(t => t.ID_TIPO_ESTAMPA);
            
            CreateTable(
                "dbo.TIPO_ESTAMPA",
                c => new
                    {
                        ID_TIPO_ESTAMPA = c.Long(nullable: false, identity: true),
                        NOME = c.String(),
                        DESCRICAO = c.String(maxLength: 255),
                        VL_METRO = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID_TIPO_ESTAMPA);
            
            CreateTable(
                "dbo.STATUS",
                c => new
                    {
                        ID_STATUS = c.Int(nullable: false, identity: true),
                        NM_STATUS = c.String(),
                        STATUS_VENDA = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_STATUS);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRODUTO", "ID_TIPO_ESTAMPA", "dbo.TIPO_ESTAMPA");
            DropIndex("dbo.PRODUTO", new[] { "ID_TIPO_ESTAMPA" });
            DropTable("dbo.STATUS");
            DropTable("dbo.TIPO_ESTAMPA");
            DropTable("dbo.PRODUTO");
            DropTable("dbo.CLIENTE");
        }
    }
}
