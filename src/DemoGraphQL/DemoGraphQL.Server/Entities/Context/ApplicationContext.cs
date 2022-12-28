namespace DemoGraphQL.Server.Entities.Context
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };

            modelBuilder.ApplyConfiguration(new UserContextConfiguration(ids));
        }
    }
}