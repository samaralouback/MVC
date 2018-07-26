using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcProjetor.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcProjetorContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcProjetorContext>>()))
            {
                // Look for any projetores.
                if (context.Projetor.Any())
                {
                    return;   // DB has been seeded
                }

                context.Projetor.AddRange(
                     new Projetor
                     {
                         Campus = "Volta Redonda",
                         Numero = 799
                     },

                     new Projetor
                     {
                         Campus = "Volta Redonda",
                         Numero = 899
                     },

                     new Projetor
                     {
                         Campus = "Volta Redonda",
                         Numero = 999
                     },

                   new Projetor
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