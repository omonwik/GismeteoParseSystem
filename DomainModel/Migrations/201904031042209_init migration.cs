namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeatherForecasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, unicode: true),
                        Temperature = c.String(nullable: false, unicode: true),
                        Feeling = c.String(nullable: false, unicode: true),
                        Wind = c.String(nullable: false, unicode: true),
                        Pressure = c.String(nullable: false, unicode: true),
                        Humidity = c.String(nullable: false, unicode: true),
                        GeomagneticField = c.String(nullable: false, unicode: true),
                        WaterTemperature = c.String(nullable: false, unicode: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeatherForecasts");
        }
    }
}
