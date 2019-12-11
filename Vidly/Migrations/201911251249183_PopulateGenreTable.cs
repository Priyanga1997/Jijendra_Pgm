namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Genres(GenreName,id)values('Action',1)");
            Sql("Insert Genres(GenreName,id)values('Comedy',2)");
            Sql("Insert Genres(GenreName,id)values('Thriller',3)");
        }
        
        public override void Down()
        {
        }
    }
}
