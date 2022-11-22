namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurriculumItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdWeb = c.Guid(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        InsertDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        Content = c.String(),
                        ProfessionalArea = c.String(),
                        TesetMigration1 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CurriculumItem");
        }
    }
}
