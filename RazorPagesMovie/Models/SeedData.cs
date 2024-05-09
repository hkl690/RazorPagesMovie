using Microsoft.EntityFrameworkCore;
using RazorPagesMovie;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any()) 
            { 
                return; // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Making Cookies",
                    ReleaseDate = DateTime.Parse("2023-2-23"),
                    Genre = "Nonfiction",
                    Price = 7.99M
                },

                new Movie
                {
                    Title = "Learning to Read",
                    ReleaseDate = DateTime.Parse("2024-4-13"),
                    Genre = "Nonfiction",
                    Price = 9.99M
                },

                new Movie
                {
                    Title = "Going Swimming",
                    ReleaseDate = DateTime.Parse("2003-1-8"),
                    Genre = "Nonfiction",
                    Price = 3.99M
                });
            context.SaveChanges();
            }
    }
 }
