namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParseDatefieldadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeatherForecasts", "ParseDate", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeatherForecasts", "ParseDate");
        }
    }
}
