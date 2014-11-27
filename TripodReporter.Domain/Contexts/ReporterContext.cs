using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripodReporter.Domain.Entities;


namespace TripodReporter.Domain.Contexts
{
    /// <summary>
    /// Derives from DbContext and Sets up all the DbSet Properties
    /// </summary>
    public class ReporterContext : DbContext
    {
        public ReporterContext() : base("DefaultConnection") { }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Insurer> Insurers { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //using fluentapi I have confiugred an optional one-to-one relationship between the entities
            base.OnModelCreating(modelBuilder);
        }
    }
}
