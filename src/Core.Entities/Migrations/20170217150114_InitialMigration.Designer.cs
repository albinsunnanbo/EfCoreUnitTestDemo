using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Core.Entities;

namespace Core.Entities.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170217150114_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.FooBar", b =>
                {
                    b.Property<int>("FooBarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.HasKey("FooBarId");

                    b.ToTable("FooBars");
                });
        }
    }
}
