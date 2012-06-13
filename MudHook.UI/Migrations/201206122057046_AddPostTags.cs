namespace MudHook.UI.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddPostTags : DbMigration
    {
        public override void Up()
        {
            AddColumn("Posts", "TagId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Posts", "TagId");
        }
    }
}
