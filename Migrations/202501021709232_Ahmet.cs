namespace CodeFirstV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ahmet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StokAdet = c.Int(nullable: false),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uruns");
        }
    }
}
