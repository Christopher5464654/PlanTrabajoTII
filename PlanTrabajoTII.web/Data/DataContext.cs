﻿namespace PlanTrabajoTII.web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PlanTrabajoTII.web.Data.Entities;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }

        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }
    }
}