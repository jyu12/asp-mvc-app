namespace Newbly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, Stock, GenreId) " +
                "VALUES('Batman', Convert(datetime, '12/04/2009', 101), " +
                "Convert(datetime, '12/04/2010', 101), 12, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
