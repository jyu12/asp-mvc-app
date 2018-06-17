namespace Newbly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES('Lego: The Movie', Convert(datetime, '04/12/2013', 101), Convert(datetime, '05/14/2015', 101), 4, 2)");

            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES('Ironman', Convert(datetime, '01/14/2012', 101), Convert(datetime, '05/14/2015', 101), 5, 3)");

            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES('Fightclub', Convert(datetime, '02/14/2004', 101), Convert(datetime, '08/14/2011', 101), 0, 4)");

            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES('Airplane', Convert(datetime, '04/14/1986', 101), Convert(datetime, '01/14/2001', 101), 1, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
