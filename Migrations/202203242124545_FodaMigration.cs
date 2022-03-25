namespace vxdlite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FodaMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdutoComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Comments = c.String(nullable: false, maxLength: 1000),
                        ThisDateTime = c.DateTime(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoID, cascadeDelete: true)
                .Index(t => t.ProdutoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoComments", "ProdutoID", "dbo.Produtoes");
            DropIndex("dbo.ProdutoComments", new[] { "ProdutoID" });
            DropTable("dbo.ProdutoComments");
        }
    }
}
