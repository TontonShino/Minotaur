using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'ApplicationDbContext'
    public class ApplicationDbContext : DbContext
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'ApplicationDbContext'
    {
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'ApplicationDbContext.ApplicationDbContext(DbContextOptions<ApplicationDbContext>)'
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'ApplicationDbContext.ApplicationDbContext(DbContextOptions<ApplicationDbContext>)'
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'ApplicationDbContext.ApplicationDbContext()'
        public ApplicationDbContext() { }
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'ApplicationDbContext.ApplicationDbContext()'
    }
}
