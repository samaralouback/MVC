using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcProjetor.Models;

namespace MvcProjetor.Models
{
    public class MvcProjetorContext : DbContext
    {
        public MvcProjetorContext (DbContextOptions<MvcProjetorContext> options)
            : base(options)
        {
        }

        public DbSet<MvcProjetor.Models.Projetor> Projetor { get; set; }
        public DbSet<MvcProjetor.Models.Auditorio> Auditorio { get; set; }
        public DbSet<MvcProjetor.Models.Laboratorio> Laboratorio { get; set; }
    }
}
