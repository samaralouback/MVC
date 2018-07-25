using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Campus = "Volta Redonda",
                         Numero = 799
                     },

                     new Movie
                     {
                         Campus = "Volta Redonda",
                         Numero = 899
                     },

                     new Movie
                     {
                         Campus = "Volta Redonda",
                         Numero = 999
                     },

                   new Movie
                   {
                       Campus = "Volta Redonda",
                       Numero = 399
                   }
                );
                context.SaveChanges();
            }
        }
    }
}