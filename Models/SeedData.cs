using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                // Look for any movies.
                //If there are any movies in the DB, the seed initializer returns and no movies are added.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
                 context.Genre.AddRange(
                    new Genre
                    {
                        Name = "Comedy",
                    },
                       new Genre
                    {
                        Name = "Horror"
                    },
                       new Genre
                    {
                        Name = "Action"
                    }
                 );

                  context.Language.AddRange(
                    new Language
                    {
                        Name = "Spanish",
                    },
                       new Language
                    {
                        Name = "English"
                    },
                       new Language
                    {
                        Name = "Korean"
                    }
                 );

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        GenreID = 1,
                        LanguageID = 1,
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        GenreID = 2,
                        LanguageID = 1,
                        Price = 8.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        GenreID = 3,
                        LanguageID = 1,
                        Price = 9.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        GenreID = 1,
                        LanguageID = 1,
                        Price = 3.99M,
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
