namespace CodeFirstV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SehirVeMusteri : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        MusteriID = c.Int(nullable: false, identity: true),
                        MusteriAd = c.String(),
                        Soyad = c.String(),
                        Cinsiyet = c.String(),
                        Gelir = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Meslek = c.String(),
                        Sehir = c.String(),
                        Yas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MusteriID);
            
            CreateTable(
                "dbo.Sehirs",
                c => new
                    {
                        SehirID = c.Int(nullable: false, identity: true),
                        SehirAdi = c.String(),
                    })
                .PrimaryKey(t => t.SehirID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sehirs");
            DropTable("dbo.Musteris");
        }
    }
}
