﻿// <auto-generated />
using System;
using CouponClipper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CouponClipper.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20241011211946_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CouponClipper.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CouponId"));

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CouponId");

                    b.HasIndex("UserId");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("CouponClipper.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CouponClipper.Models.UserCouponClipping", b =>
                {
                    b.Property<int>("UserCouponClippingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserCouponClippingId"));

                    b.Property<int?>("ClippedCouponCouponId")
                        .HasColumnType("int");

                    b.Property<string>("CouponId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserCouponClippingId");

                    b.HasIndex("ClippedCouponCouponId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCouponClippings");
                });

            modelBuilder.Entity("CouponClipper.Models.Coupon", b =>
                {
                    b.HasOne("CouponClipper.Models.User", "Clipper")
                        .WithMany("ClippedCoupon")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clipper");
                });

            modelBuilder.Entity("CouponClipper.Models.UserCouponClipping", b =>
                {
                    b.HasOne("CouponClipper.Models.Coupon", "ClippedCoupon")
                        .WithMany("UserClippings")
                        .HasForeignKey("ClippedCouponCouponId");

                    b.HasOne("CouponClipper.Models.User", "ClippingUser")
                        .WithMany("CouponClippings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClippedCoupon");

                    b.Navigation("ClippingUser");
                });

            modelBuilder.Entity("CouponClipper.Models.Coupon", b =>
                {
                    b.Navigation("UserClippings");
                });

            modelBuilder.Entity("CouponClipper.Models.User", b =>
                {
                    b.Navigation("ClippedCoupon");

                    b.Navigation("CouponClippings");
                });
#pragma warning restore 612, 618
        }
    }
}
