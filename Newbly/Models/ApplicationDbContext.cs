using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Newbly.Models
{
    /* Code FirstMigration
     * Nuget "Add-Migration" to add a migration class
     * Follow the convention "Add-Migration WhatItWillDo" ex "AddIsSubscribedToCustomer"
     * 
     * 
     * "Add-Migration InitialModel -force" -force will overwrite current context
     * 
     * Updating a Domain Model
     * Nuget "Update-Database"
     * 
     * When deploying database
     * update-database -script -SourceMigration:
     * Generates a SQL script of all the migration
     * 
     * -SourceMigration: "name of migration class"
     * The script will contain up to the the sourceMigration class
     */

    // IdentityDbContex accessing the database
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Creating a context to represent the Customers in the Database
        // DbSet<DomainModel> TableName {get;set}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}