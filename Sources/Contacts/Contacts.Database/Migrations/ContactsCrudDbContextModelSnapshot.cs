﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyCompany.Crm.Contacts.Database.Migrations
{
    [DbContext(typeof(ContactsCrudDbContext))]
    partial class ContactsCrudDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.CompanyGroup", b =>
                {
                    b.Property<Guid>("CompanyId");

                    b.Property<Guid>("GroupId");

                    b.HasKey("CompanyId", "GroupId");

                    b.ToTable("CompanyGroup");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.CompanyTag", b =>
                {
                    b.Property<Guid>("CompanyId");

                    b.Property<Guid>("TagId");

                    b.HasKey("CompanyId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("CompanyTag");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Groups.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Groups.GroupTag", b =>
                {
                    b.Property<Guid>("GroupId");

                    b.Property<Guid>("TagId");

                    b.HasKey("GroupId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("GroupTag");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Tags.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.Company", b =>
                {
                    b.OwnsOne("MyCompany.Crm.Contacts.Companies.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CompanyId");

                            b1.Property<string>("City");

                            b1.Property<string>("Street");

                            b1.Property<string>("ZipCode");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.HasOne("MyCompany.Crm.Contacts.Companies.Company", "Company")
                                .WithOne("Address")
                                .HasForeignKey("MyCompany.Crm.Contacts.Companies.Address", "CompanyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsMany("MyCompany.Crm.Contacts.Companies.Phone", "Phones", b1 =>
                        {
                            b1.Property<Guid>("CompanyId");

                            b1.Property<string>("Number");

                            b1.HasKey("CompanyId", "Number");

                            b1.ToTable("Phone");

                            b1.HasOne("MyCompany.Crm.Contacts.Companies.Company")
                                .WithMany("Phones")
                                .HasForeignKey("CompanyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.CompanyGroup", b =>
                {
                    b.HasOne("MyCompany.Crm.Contacts.Companies.Company", "Company")
                        .WithMany("Groups")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyCompany.Crm.Contacts.Groups.Group", "Group")
                        .WithMany("Companies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.CompanyTag", b =>
                {
                    b.HasOne("MyCompany.Crm.Contacts.Companies.Company", "Company")
                        .WithMany("Tags")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyCompany.Crm.Contacts.Tags.Tag", "Tag")
                        .WithMany("Companies")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Groups.GroupTag", b =>
                {
                    b.HasOne("MyCompany.Crm.Contacts.Groups.Group", "Group")
                        .WithMany("Tags")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyCompany.Crm.Contacts.Tags.Tag", "Tag")
                        .WithMany("Groups")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
