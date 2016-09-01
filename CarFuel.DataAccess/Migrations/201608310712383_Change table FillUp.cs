namespace CarFuel.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetableFillUp : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tblFillUp", newName: "FillUp");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FillUp", newName: "tblFillUp");
        }
    }
}
