using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcProjetor.Models
{
    public class MvcProjetorContext : DbContext
    {
        public MvcProjetorContext (DbContextOptions<MvcProjetorContext> options)
            : base(options)
        {
        }

        public DbSet<MvcProjetor.Models.Projetor> Projetor { get; set; }
    }
}
