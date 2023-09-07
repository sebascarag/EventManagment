using EventManagment.DataAccess.Interceptors;
using EventMangment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventManagment.DataAccess
{
    public class EventManagmentDbContext : DbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        public DbSet<EventLog> EventLogs { get; set; }
        public EventManagmentDbContext() { } // important for create initial migration
        public EventManagmentDbContext(DbContextOptions options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                // string temporary connection for build database
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;database=Registration;Trusted_Connection=True;MultipleActiveResultSets=True;");

            if (_auditableEntitySaveChangesInterceptor != null)
                optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Use Entities Configurations
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
