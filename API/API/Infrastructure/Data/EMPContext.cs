using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TIQRI.EMP.ApplicationCore.Entities;

namespace TIQRI.EMP.Infrastructure.Data
{
    public class EMPContext : DbContext
    {
        //Add-Migration ClientTbl -Project TIQRI.EMP.Infrastructure
        //Update-Database
        //Remove-Migration
        public EMPContext(DbContextOptions<EMPContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(ConfigureClient);
            // modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<User>(ConfigureUser);

        }
       
        private void ConfigureClient(EntityTypeBuilder<Client> builder)
        {

            builder.ToTable("Client");

            builder.Property(ci => ci.Id)
                .IsRequired();
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(u => u.Id)
                .IsRequired();
        }
    }
}
