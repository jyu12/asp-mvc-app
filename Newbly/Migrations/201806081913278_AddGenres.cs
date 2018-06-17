namespace Newbly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Type) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Type) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Type) VALUES ('Family')");
            Sql("INSERT INTO Genres (Type) VALUES ('Action')");
        }

        public override void Down()
        {
        }
    }
}
