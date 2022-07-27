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
                        ID_CLIENTE = c.Long(nullable: false, identity: true),
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
                        LARGURA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ALTURA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ID_TIPO_ESTAMPA = c.Long(nullable: false),
                        DT_REGISTRO = c.DateTime(),
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
                        ID_STATUS = c.Long(nullable: false, identity: true),
                        NM_STATUS = c.String(),
                        STATUS_VENDA = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_STATUS);
            
            CreateTable(
                "dbo.TELEFONE",
                c => new
                    {
                        ID_TELEFONE = c.Int(nullable: false, identity: true),
                        DDD = c.Int(nullable: false),
                        TELEFONE = c.Int(nullable: false),
                        ID_CLIENTE = c.Long(nullable: false),
                        ID_VENDEDOR = c.Long(nullable: false),
                        ATIVO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_TELEFONE)
                .ForeignKey("dbo.CLIENTE", t => t.ID_CLIENTE)
                .ForeignKey("dbo.VENDEDOR", t => t.ID_VENDEDOR)
                .Index(t => t.ID_CLIENTE)
                .Index(t => t.ID_VENDEDOR);
            
            CreateTable(
                "dbo.VENDEDOR",
                c => new
                    {
                        ID_VENDEDOR = c.Long(nullable: false, identity: true),
                        NOME = c.String(nullable: false),
                        DT_NASC = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_VENDEDOR);
            
            CreateTable(
                "dbo.VENDA_ITEM",
                c => new
                    {
                        ID_VENDA_ITEM = c.Int(nullable: false, identity: true),
                        ID_PRODUTO = c.Long(nullable: false),
                        ID_VENDA = c.Long(nullable: false),
                        QUANTIDADE = c.Int(nullable: false),
                        VL_TOTAL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_VENDA_ITEM)
                .ForeignKey("dbo.PRODUTO", t => t.ID_PRODUTO)
                .ForeignKey("dbo.VENDA", t => t.ID_VENDA)
                .Index(t => t.ID_PRODUTO)
                .Index(t => t.ID_VENDA);
            
            CreateTable(
                "dbo.VENDA",
                c => new
                    {
                        ID_VENDA = c.Long(nullable: false, identity: true),
                        DT_REGISTRO = c.DateTime(nullable: false),
                        ID_CLIENTE = c.Long(nullable: false),
                        ID_VENDEDOR = c.Long(nullable: false),
                        ID_STATUS = c.Long(nullable: false),
                        VL_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID_VENDA)
                .ForeignKey("dbo.CLIENTE", t => t.ID_CLIENTE)
                .ForeignKey("dbo.STATUS", t => t.ID_STATUS)
                .ForeignKey("dbo.VENDEDOR", t => t.ID_VENDEDOR)
                .Index(t => t.ID_CLIENTE)
                .Index(t => t.ID_VENDEDOR)
                .Index(t => t.ID_STATUS);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VENDA_ITEM", "ID_VENDA", "dbo.VENDA");
            DropForeignKey("dbo.VENDA", "ID_VENDEDOR", "dbo.VENDEDOR");
            DropForeignKey("dbo.VENDA", "ID_STATUS", "dbo.STATUS");
            DropForeignKey("dbo.VENDA", "ID_CLIENTE", "dbo.CLIENTE");
            DropForeignKey("dbo.VENDA_ITEM", "ID_PRODUTO", "dbo.PRODUTO");
            DropForeignKey("dbo.TELEFONE", "ID_VENDEDOR", "dbo.VENDEDOR");
            DropForeignKey("dbo.TELEFONE", "ID_CLIENTE", "dbo.CLIENTE");
            DropForeignKey("dbo.PRODUTO", "ID_TIPO_ESTAMPA", "dbo.TIPO_ESTAMPA");
            DropIndex("dbo.VENDA", new[] { "ID_STATUS" });
            DropIndex("dbo.VENDA", new[] { "ID_VENDEDOR" });
            DropIndex("dbo.VENDA", new[] { "ID_CLIENTE" });
            DropIndex("dbo.VENDA_ITEM", new[] { "ID_VENDA" });
            DropIndex("dbo.VENDA_ITEM", new[] { "ID_PRODUTO" });
            DropIndex("dbo.TELEFONE", new[] { "ID_VENDEDOR" });
            DropIndex("dbo.TELEFONE", new[] { "ID_CLIENTE" });
            DropIndex("dbo.PRODUTO", new[] { "ID_TIPO_ESTAMPA" });
            DropTable("dbo.VENDA");
            DropTable("dbo.VENDA_ITEM");
            DropTable("dbo.VENDEDOR");
            DropTable("dbo.TELEFONE");
            DropTable("dbo.STATUS");
            DropTable("dbo.TIPO_ESTAMPA");
            DropTable("dbo.PRODUTO");
            DropTable("dbo.CLIENTE");
        }
    }
}
