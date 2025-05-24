using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
    }
}
