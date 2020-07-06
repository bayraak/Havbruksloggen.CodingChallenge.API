using System;
using Havbruksloggen.CodingChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Havbruksloggen.CodingChallenge.Core
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<CrewMember> Owners { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            //modelBuilder.Entity<User>(entity => {
            //    entity.HasIndex(e => e.Username).IsUnique();
            //});

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DeptNo)
                    .HasName("dept_no");

                entity.Property(e => e.EmpNo).ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

            });

            modelBuilder.Entity<Boat>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Producer).IsUnicode(false);

                entity.HasMany(d => d.CrewMembers)
                    .WithOne(p => p.Boat)
                    .HasForeignKey(d => d.BoatId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Boats_CrewMemberId");

            modelBuilder.Entity<CrewMember>(entityTypeBuilder =>
                {
                    entityTypeBuilder.Property(e => e.Name).IsUnicode(false);

                    entityTypeBuilder.Property(e => e.Email).IsUnicode(false);
                });
            });
        }
    }
}
