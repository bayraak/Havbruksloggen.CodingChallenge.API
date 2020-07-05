﻿// <auto-generated />
using System;
using Havbruksloggen.CodingChallenge.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Havbruksloggen.CodingChallenge.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Havbruksloggen.CodingChallenge.Core.Models.Boat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("B")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int?>("BuildNumber")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LoA")
                        .HasColumnType("decimal(5, 2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Producer")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("boats");
                });

            modelBuilder.Entity("Havbruksloggen.CodingChallenge.Core.Models.CrewMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BoatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CertifiedUntil")
                        .HasColumnType("datetime2");

                    b.Property<int>("CrewRole")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("BoatId");

                    b.ToTable("crew_members");
                });

            modelBuilder.Entity("Havbruksloggen.CodingChallenge.Core.Models.Employee", b =>
                {
                    b.Property<int>("EmpNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasMaxLength(16)
                        .IsUnicode(false);

                    b.HasKey("EmpNo");

                    b.HasIndex("DeptNo")
                        .HasName("dept_no");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Havbruksloggen.CodingChallenge.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(63)")
                        .HasMaxLength(63);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(63)")
                        .HasMaxLength(63);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(63)")
                        .HasMaxLength(63);

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Havbruksloggen.CodingChallenge.Core.Models.Boat", b =>
                {
                    b.HasOne("Havbruksloggen.CodingChallenge.Core.Models.User", "User")
                        .WithMany("Boats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Havbruksloggen.CodingChallenge.Core.Models.CrewMember", b =>
                {
                    b.HasOne("Havbruksloggen.CodingChallenge.Core.Models.Boat", "Boat")
                        .WithMany("CrewMembers")
                        .HasForeignKey("BoatId")
                        .HasConstraintName("FK_Boats_CrewMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
