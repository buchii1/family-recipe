using FamilyRecipesApp.Server.Models;
using FamilyRecipesApp.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamilyRecipesApp.Server.Data
{
    // ApplicationDBContext class inherits from IdentityDbContext for handling identity-related functionality
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor accepting DbContextOptions and passing it to the base class constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        // DbSet for accessing and manipulating Recipe entities in the database
        public DbSet<Recipe> Recipes { get; set; }
    }
}
