namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurriculumItem", "TesetMigrationX", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CurriculumItem", "TesetMigrationX");
        }
    }
}
