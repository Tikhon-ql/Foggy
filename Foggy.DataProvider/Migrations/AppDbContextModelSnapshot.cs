﻿// <auto-generated />
using System;
using Foggy.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Foggy.DataProvider.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Foggy.DataProvider.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Foggy.DataProvider.Models.Identity.UserRefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Foggy.DataProvider.Models.SocialNetwork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("sn_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SocialNetworkToNotifies");

                    b.HasDiscriminator<string>("sn_type").HasValue("sn_base");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Foggy.DataProvider.Models.ToRemember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ToRemembers");
                });

            modelBuilder.Entity("Foggy.DataProvider.Models.SocialNetworks.TelegramSN", b =>
                {
                    b.HasBaseType("Foggy.DataProvider.Models.SocialNetwork");

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("sn_telegram");
                });

            modelBuilder.Entity("Foggy.DataProvider.Models.Identity.UserRefreshToken", b =>
                {
                    b.HasOne("Foggy.DataProvider.Models.Identity.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Foggy.DataProvider.Models.Identity.UserRefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Foggy.DataProvider.Models.SocialNetwork", b =>
                {
                    b.HasOne("Foggy.DataProvider.Models.Identity.User", "User")
                        .WithOne("SocialNetworkToNotify")
                        .HasForeignKey("Foggy.DataProvider.Models.SocialNetwork", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Foggy.DataProvider.Models.ToRemember", b =>
                {
                    b.HasOne("Foggy.DataProvider.Models.Identity.User", "User")
                        .WithMany("ToRemembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Foggy.DataProvider.Models.Identity.User", b =>
                {
                    b.Navigation("RefreshToken")
                        .IsRequired();

                    b.Navigation("SocialNetworkToNotify")
                        .IsRequired();

                    b.Navigation("ToRemembers");
                });
#pragma warning restore 612, 618
        }
    }
}
