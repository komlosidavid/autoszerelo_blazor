// <copyright file="AppDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo.API.Data
{
    using Autoszerelo.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// <see cref="Client"/> Gets or sets entities.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// <see cref="Car"/> Gets or sets .
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// <see cref="Work"/> Gets or sets .
        /// </summary>
        public DbSet<Work> Works { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">Databse options.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// On model creating function.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("Work");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
