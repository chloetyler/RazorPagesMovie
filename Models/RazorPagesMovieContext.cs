using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        // The following code creates a DbSet property for the entity set. 
        // In Entity Framework terminology, an entity set typically 
        // corresponds to a database table, and an entity corresponds 
        // to a row in the table.

        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }
        public DbSet<RazorPagesMovie.Models.Genre> Genre { get; set; }
        public DbSet<RazorPagesMovie.Models.Language> Language { get; set; }
    }
}

// console commands used:
// dotnet ef migrations add InitialCreate
// dotnet ef database update
//----------------------------------------------------------------------------------------------------

// dotnet ef migrations add InitialCreate:
// The ef migrations add InitialCreate command generates code to create the initial database schema.
// The schema is based on the model specified in the DbContext (In the RazorPagesMovieContext.cs file).
// The InitialCreate argument is used to name the migrations. Any name can be used, but by convention
// a name is selected that describes the migration.

// dotnet ef database update:
// The ef database update command runs the Up method in the Migrations/<time-stamp>_InitialCreate.cs file.
// The Up method creates the database.

// The Add-Migration command generates code to create the initial database schema. The schema is based
// on the model specified in the RazorPagesMovieContext (In the Data/RazorPagesMovieContext.cs file).
// The Initial argument is used to name the migrations. Any name can be used, but by convention a name 
//that describes the migration is used. For more information, see Tutorial: Using the migrations feature 
//- ASP.NET MVC with EF Core.

// The Update-Database command runs the Up method in the Migrations/{time-stamp}_InitialCreate.cs file,
// which creates the database.