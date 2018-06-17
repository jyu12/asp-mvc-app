namespace Newbly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /* 
     * In Code First Migration - The practice is to not touch the Database directly
     * Should always use migration techiques. Types are part of the database schema
     * and the Application, so migration is needed
     * 
     */
    public partial class PopulationMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");
        }
        
        public override void Down()
        {

        }
    }
}
